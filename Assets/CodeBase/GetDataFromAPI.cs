using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class GetDataFromAPI : MonoBehaviour
{
    private HttpClient _httpClient;
    [SerializeField] private Data _data;


    IEnumerator Start()
    {
        var insecureHandler = InsecureHandlerFactory.GetInsecureHandler();
        _httpClient = new HttpClient(insecureHandler);
        StartCoroutine(GetWeatherForecastRepeatedly());
        yield return null;
    }

    IEnumerator GetWeatherForecastRepeatedly()
    {
        while (true)
        {
            yield return GetWeatherForecastAsync();
            yield return new WaitForSeconds(5); // Задержка в 5 секунд между каждым запросом
        }
    }

    public async Task GetWeatherForecastAsync()
    {
        var response = await _httpClient.GetAsync($@"https://localhost:7171/WeatherForecast/GetWeatherForecast");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var jsonString = WrapJsonArray(result);
            _data.AddWeatherDataFromJson(jsonString);
        }
        else
        {
            Debug.Log($"Error: {response.StatusCode}");
        }
    }

    // Метод для оборачивания JSON-массива в объект
    public string WrapJsonArray(string jsonArray)
    {
        return "{\"items\":" + jsonArray + "}";
    }

    public static class InsecureHandlerFactory
    {
        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert!.Issuer.Equals("CN=Kubernetes Ingress Controller Fake Certificate, O=Acme Co") || cert!.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };

            return handler;
        }
    }

}
