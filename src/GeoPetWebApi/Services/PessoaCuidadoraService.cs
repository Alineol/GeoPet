using projetoFinal.db.Repository;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.Controllers.inputs;
using projetoFinal.Controllers;
using System.Security.Cryptography;
using System.Text;
using GeoPetWebApi.Controllers.inputs;
using GeoPetWebApi.JWT;

namespace projetoFinal.Services
{
    public class PessoaCuidadoraService {
        private readonly PessoaCuidadoraRepository _repository;
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public PessoaCuidadoraService(PessoaCuidadoraRepository repository, HttpClient client, IConfiguration config) {
            _repository = repository;
            _client = client;
            _config = config;
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
                Senha = GenerateHash(pessoaCuidadora.Senha),
                CEP = pessoaCuidadora.CEP,
                Status = true,
            };
            output.RowsAffected = _repository.CreatePessoaCuidadora(model);
            output.SucessMessage = $"Created Client with id {model.Id}";
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

        public string GenerateHash(string password) {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public IEnumerable<PessoaCuidadoraModel>? GetAll() {
            var list = _repository.GetAll();
            return list;
        }

        public ResultRowstOuput Login(LoginInput data) { 
            var outupt = new ResultRowstOuput();
            var has = GenerateHash(data.Senha);
            var check = _repository.login(has, data.Email);
            if (check != null) {
                outupt.SucessMessage = new TokenGenerator(_config).Generate();
                return outupt;
            }
            outupt.ErrorMessage = "login failed, email or password incorrect!";
            return outupt ;
         
        }

    };
};
