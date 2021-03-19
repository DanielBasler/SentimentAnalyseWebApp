using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using SentimentAnalyseWebAppML.Model;

namespace SentimentAnalyseWebApp.Controllers
{
    public class SentimentController : Controller
    {
        [HttpGet]
        public IActionResult SentimentAnalyse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SentimentAnalyse(ModelInput input)
        {
            
            MLContext mlContext = new MLContext();

            ITransformer mlModel = mlContext.Model.Load(@"..\SentimentAnalyseWebAppML.Model\MLModel.zip", out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            ModelOutput result = predEngine.Predict(input);
            ViewBag.Result = result;
            return View();
        }
    }
}
