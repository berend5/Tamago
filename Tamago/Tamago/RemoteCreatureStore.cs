using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Tamago
{
    public class RemoteCreatureStore : Interface1<Creature>
    {
        private HttpClient client = new HttpClient();

        public async Task<bool> CreateItem(Creature item)
        {
            string creatureAsText = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(creatureAsText, Encoding.UTF8, "application.json"));

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    string postedCreatureAsText = await response.Content.ReadAsStringAsync();

                    Creature postedCreature = JsonConvert.DeserializeObject<Creature>(postedCreatureAsText);

                    Preferences.Set("MyCreatureID", JsonConvert.ToString(postedCreature));

                    return await Task.FromResult(true);
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
            
            
        }

        public Task<bool> DeleteItem(Creature item)
        {
            throw new NotImplementedException();
        }

        public async Task<Creature> ReadItem()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://tamagotchi.hku.nl/api/creatures");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                var creature = JsonConvert.DeserializeObject<Creature>(responseString);

                return creature;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateItem(Creature item)
        {
            string creatureText = JsonConvert.SerializeObject(item);

            var httpClient = new HttpClient();

            string httpAddress = "https://tamagotchi.hku.nl/api/creatures/" + Preferences.Get("MyCreatureID", 999);

            await httpClient.PutAsync(httpAddress, new StringContent(creatureText, Encoding.UTF8, "application/json"));

            return true;
        }
    }
}
