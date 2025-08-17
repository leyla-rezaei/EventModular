using EventModular.Shared.Dtos.Live;
using FluentValidation;

namespace EventModular.Server.Modules.Live.Application.Validations;
public class SendLiveChatMessageValidation : AbstractValidator<LiveChatMessageRequestDto>
{
    public SendLiveChatMessageValidation()
    {
     
        RuleFor(x => x.LiveRoomId).NotEmpty();
        RuleFor(x => x.SenderId).NotEmpty();
    }
}
