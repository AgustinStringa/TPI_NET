﻿using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;
using Newtonsoft.Json;
using Azure;

namespace ClientService.Commission
{
    public class ErrorResponse
    {
        public string Message { get; set; }
    }
    public class CommissionService : ICommissionService
    {

        private readonly HttpClient _httpClient;
        private string _apiUrl = "";
        public CommissionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent + "\\ClientService\\";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
                .Build();
            _apiUrl = configuration["ApiUrl:Base"];
            _apiUrl += "/commissions/";
        }

        public async Task<IEnumerable<ApplicationCore.Model.Commission>> GetAll()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetStringAsync(_apiUrl);
                var commissions = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Commission>>(response);

                return commissions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllWithCurriculum()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetStringAsync(_apiUrl + "?populate=curriculum");
                var commissions = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Commission>>(response);

                return commissions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllByCurriculumIdAndLevel(int curriculumId, int level)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetStringAsync(_apiUrl + $"?curriculumId={curriculumId}&level={level}");
                var commissions = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Commission>>(response);

                return commissions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationCore.Model.Commission> GetById(int id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetStringAsync(_apiUrl + id.ToString());
                var commission = JsonConvert.DeserializeObject<ApplicationCore.Model.Commission>(response);

                return commission;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(ApplicationCore.Model.Commission commission)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(commission), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                    throw new Exception(errorResponse?.Message ?? "Error al crear la comision");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(ApplicationCore.Model.Commission commission)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(commission), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(_apiUrl + commission.Id.ToString(), jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                    throw new Exception(errorResponse?.Message ?? "Error al actualizar la comision");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.DeleteAsync(_apiUrl + id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                    throw new Exception(errorResponse.Message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
