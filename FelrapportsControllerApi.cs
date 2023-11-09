using FelrapportsApi.Controllers;
using FelrapportsApi.Data;
using FelrapportsApi.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;


namespace FelrapportsApi.Test
{
    public class FelrapportsControllerApi: IDisposable
    {
        private static DbContextOptions<FelrapportsApiContext> dbContextOptions = new DbContextOptionsBuilder<FelrapportsApiContext>()
            .UseInMemoryDatabase(databaseName: "FelrapportsApiContext-17375191-c777-4fb2-ba75-eae4f4ebd8f8")
            .Options; 

        FelrapportsApiContext context;
        public FelrapportsControllerApi()
        {
            context = new FelrapportsApiContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
        }

        public void SeedDatabase()
        {
            List<Felrapport> felrapporter = new List<Felrapport>()
            {
                new Felrapport() { Id = 1, Description = "Dåligt!"},
                new Felrapport() { Id = 2, Description = "Mellanbra!"},
                new Felrapport() { Id = 3, Description = "Bra!"},
                new Felrapport() { Id = 4, Description = "Excellenté!"}

            };
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task GetFelrapportTest()
        {
            // Arrange
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            // Act
            var response = await httpClient.GetAsync("https://localhost:7144/api/Felrapports");
            var stringResult = await response.Content.ReadAsStringAsync();
            List<Felrapport> felrapporter = JsonConvert.DeserializeObject<IEnumerable<Felrapport>>(stringResult).ToList();
            // Assert
            Assert.Equal(3 , felrapporter.Count() );
        }     
    }
}