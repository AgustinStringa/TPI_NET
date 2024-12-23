﻿using ApplicationCore.Model;
using ClientService.Commission;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly HttpClient _httpClient;
        private string _apiUrl = "";

        public SubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent + "\\ClientService\\";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
                .Build();
            _apiUrl = configuration["ApiUrl:Base"];
            _apiUrl += "/subjects/";
        }

        public async Task<IEnumerable<ApplicationCore.Model.Subject>> GetAllWithCurriculum()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetStringAsync(_apiUrl + "?populate=curriculum");
                var subjects = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Subject>>(response);
                return subjects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ApplicationCore.Model.Subject>> GetAllByCurriculumId(int curriculumId)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetStringAsync(_apiUrl + $"?curriculumId={curriculumId}");
                var subjects = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Subject>>(response);
                return subjects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationCore.Model.Subject> GetByIdWithCurriculumAndCourses(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(ApplicationCore.Model.Subject subject)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(subject), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(ApplicationCore.Model.Subject subject)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(subject), Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(_apiUrl + subject.Id.ToString(), jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                    throw new Exception(errorResponse?.Message ?? "Error al actualizar la materia");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(int id){
            try
            {
                try
                {
                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await _httpClient.DeleteAsync(_apiUrl + id.ToString());
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException e)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
