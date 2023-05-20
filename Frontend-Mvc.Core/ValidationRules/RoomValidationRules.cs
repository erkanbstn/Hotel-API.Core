using FluentValidation;
using Frontend_Mvc.Core.ViewModels.Room;

namespace Frontend_Mvc.Core.ValidationRules
{
    public class RoomValidationRules:AbstractValidator<RoomViewModel>
    {
        public RoomValidationRules()
        {
            RuleFor(b => b.No).NotEmpty().WithMessage("Oda No Alanı Boş Geçilemez."); 
            RuleFor(b => b.Title).NotEmpty().WithMessage("Oda No Alanı Boş Geçilemez."); 
            RuleFor(b => b.BathCount).NotEmpty().WithMessage("Oda Banyo Sayısı Alanı Boş Geçilemez."); 
            RuleFor(b => b.BedCount).NotEmpty().WithMessage("Oda Yatak Sayısı Alanı Boş Geçilemez."); 
        }
    }
}
