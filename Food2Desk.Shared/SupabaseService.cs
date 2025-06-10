using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared
{
    public static class SupabaseService
    {
        private const string SupabaseUrl = "https://dztnpppziryhmoohygjk.supabase.co";
        private const string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImR6dG5wcHB6aXJ5aG1vb2h5Z2prIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDc5MzUzNDYsImV4cCI6MjA2MzUxMTM0Nn0.0IDJ-GMhc6PnXrUrgM3stB4WmIz00CKrtxM5zyT7r50";
        private const string Bucket = "product-images";

        public static async Task<string> UploadImage(IFormFile file)
        {
            using var client = new HttpClient();

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var url = $"{SupabaseUrl}/storage/v1/object/{Bucket}/{fileName}";


            using var content = new MultipartFormDataContent();
            using var streamContent = new StreamContent(file.OpenReadStream());

            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            streamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = $"\"{file.FileName}\"" 
            };

            content.Add(streamContent, "file");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SupabaseKey);

            var response = await client.PostAsync(url, content);

            var togpt = response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro no upload da imagem: {response.StatusCode} - {error}");
            }

            // URL pública
            return $"https://dztnpppziryhmoohygjk.supabase.co/storage/v1/object/public/product/{fileName}";
        }

    }
}
