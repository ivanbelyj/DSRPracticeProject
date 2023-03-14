namespace DSRNetSchool.Api.Pages;

using DSRPracticeProject.Common;

using DSRPracticeProject.Api.Settings;
using DSRPracticeProject.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

public class IndexModel : PageModel
{
    [BindProperty]
    public bool OpenApiEnabled => settings.Enabled;

    [BindProperty]
    public string Version => Assembly.GetExecutingAssembly().GetAssemblyVersion();

    [BindProperty]
    public string HelloMessage => apiSettings.HelloMessage;


    private readonly OpenApiSettings settings;
    private readonly ApiSpecialSettings apiSettings;

    public IndexModel(OpenApiSettings settings, ApiSpecialSettings apiSettings)
    {
        this.settings = settings;
        this.apiSettings = apiSettings;
    }

    public void OnGet()
    {
    }
}
