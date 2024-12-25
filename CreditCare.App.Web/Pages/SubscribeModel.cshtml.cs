using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using CreditCare.Domain;
using CreditCare.Service;

public class SubscribeModel : PageModel
{
    private readonly StripeService _stripeService;
    private readonly UserManager<ApplicationUser> _userManager;

    public SubscribeModel(StripeService stripeService, UserManager<ApplicationUser> userManager)
    {
        _stripeService = stripeService;
        _userManager = userManager;
    }

    // This action redirects the user to the Stripe checkout page
    public IActionResult OnGet()
    {
        var checkoutUrl = _stripeService.CreateCheckoutSession(
            User.Identity.Name, // Use the user's email or username for the checkout session
            "https://your-domain.com/Subscription/Success", // Redirect URL on success
            "https://your-domain.com/Subscription/Cancel"   // Redirect URL on cancel
        );

        return Redirect(checkoutUrl);
    }

    // This action handles the success response from Stripe after payment
    public async Task<IActionResult> OnGetSuccess()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            user.IsSubscribed = true;
            user.SubscriptionEndDate = DateTime.UtcNow.AddMonths(1); // Example: 1-month subscription
            await _userManager.UpdateAsync(user);
        }

        return RedirectToPage("/Index");
    }

    // This action handles the cancel response from Stripe if the user cancels the payment
    public IActionResult OnGetCancel()
    {
        return RedirectToPage("/Index");
    }
}
