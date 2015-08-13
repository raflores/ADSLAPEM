using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ADS.LAPEM.Entities.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace ADS.LAPEM.Entities.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}