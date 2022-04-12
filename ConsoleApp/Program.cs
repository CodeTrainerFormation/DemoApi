using ConsoleApp;
using Newtonsoft.Json;

HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://localhost:5001");


//Task<HttpResponseMessage> response = httpClient.GetAsync("/Person/1");
//response.Wait();

HttpResponseMessage response = await httpClient.GetAsync("/Person/1");

string content = await response.Content.ReadAsStringAsync();

Person p = JsonConvert.DeserializeObject<Person>(content);


p.FirstName = "Marshall";

string s = JsonConvert.SerializeObject(p);

await httpClient.PostAsync("", new StringContent(s));

