using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using OpenAI_API.Completions;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGpt")]
        public async Task<IActionResult> GetChatGptResponse(string query) {
            string chatGptResponse = null;
            var openAi = new OpenAIAPI(Environment.GetEnvironmentVariable("OPENAI_CHATGPT_KEY"));
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 1024;
            var completions = await openAi.Completions.CreateAndFormatCompletion(completionRequest);
            foreach (var completion in completions)
            {
                chatGptResponse += completion;
            }

            return Ok(chatGptResponse);

        }
    }
}
