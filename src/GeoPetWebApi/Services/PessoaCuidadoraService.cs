using projetoFinal.db.Repository;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.Controllers.inputs;
using projetoFinal.Controllers;

namespace projetoFinal.Services
{
    public class PessoaCuidadoraService {
        private readonly PessoaCuidadoraRepository _repository;
        private readonly HttpClient _client;

        public PessoaCuidadoraService(PessoaCuidadoraRepository repository, HttpClient client) {
            _repository = repository;
            _client = client;
        }

        public async Task<ResultRowstOuput> CreatePessoaCuidadora(PessoaCuidadoraInput pessoaCuidadora) {
            var output = new ResultRowstOuput();
            // confere se tem alguém já cadastrado com o mesmo cpf
            var check = _repository.GetByEmail(pessoaCuidadora.Email);
            if (check != null) {
                output.ErrorMessage = "Email Já cadastrado";
                return output;
            };
            // confere o cep
            var cep = await CheckCEP(pessoaCuidadora.CEP);
            if (cep == false) {
                output.ErrorMessage = "CEP inválido";
                return output;
            }

            // tudo ok? cria uma pessoa cuidadora do jeito que o bd espera 
            var model = new PessoaCuidadoraModel() {
                Nome = pessoaCuidadora.Nome,
                Email = pessoaCuidadora.Email,
                Senha = pessoaCuidadora.Senha,
                CEP = pessoaCuidadora.CEP,
                Status = true,
            };
            output.RowsAffected = _repository.CreatePessoaCuidadora(model);
            return output;
        } 

        public async Task<bool> CheckCEP(string cep) {
            var response = await _client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var result = await response.Content.ReadAsStringAsync();
            if (result.Contains("cep")) {
                return true;
            }
            return false;
        }

        public IEnumerable<PessoaCuidadoraModel>? GetAll() {
            var list = _repository.GetAll();
            return list;
        }
    };
};
