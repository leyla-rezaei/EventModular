namespace EventModular.Shared.Constants.Response;

/// <summary>
/// Smart Enum for API/Module responses
/// </summary>
public record ResponseStatus
{
    public string Value { get; private set; }

    [JsonConstructor]
    protected ResponseStatus(string value)
    {
        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(ResponseStatus status) => status.Value;

    public static ResponseStatus Success = new(nameof(Success));
    public static ResponseStatus Failed = new(nameof(Failed));
    public static ResponseStatus NotFound = new(nameof(NotFound));
    public static ResponseStatus AlreadyExists = new(nameof(AlreadyExists));
    public static ResponseStatus ValidationError = new(nameof(ValidationError));
    public static ResponseStatus Unauthorized = new(nameof(Unauthorized));
    public static ResponseStatus Forbidden = new(nameof(Forbidden));
    public static ResponseStatus Conflict = new(nameof(Conflict));
    public static ResponseStatus ServerError = new(nameof(ServerError));
    public static ResponseStatus UnknownError = new(nameof(UnknownError)); 


    #region User
    public static ResponseStatus UserNotFound = new(nameof(UserNotFound));
    public static ResponseStatus UserLockedOut = new(nameof(UserLockedOut));
    public static ResponseStatus InvalidCredentials = new(nameof(InvalidCredentials));
    public static ResponseStatus UserAlreadyRegistered = new(nameof(UserAlreadyRegistered));
    #endregion

    #region AffiliateMarketing
    public static ResponseStatus AffiliateNotFound = new(nameof(AffiliateNotFound));
    public static ResponseStatus AffiliateAlreadyExists = new(nameof(AffiliateAlreadyExists));
    #endregion

    #region Categories
    public static ResponseStatus CategoryNotFound = new(nameof(CategoryNotFound));
    public static ResponseStatus CategoryAlreadyExists = new(nameof(CategoryAlreadyExists));
    #endregion

    #region Comments
    public static ResponseStatus CommentNotFound = new(nameof(CommentNotFound));
    public static ResponseStatus CommentNotAllowed = new(nameof(CommentNotAllowed));
    #endregion

    #region Contents
    public static ResponseStatus ContentNotFound = new(nameof(ContentNotFound));
    public static ResponseStatus DuplicateContent = new(nameof(DuplicateContent));
    #endregion

    #region Courses
    public static ResponseStatus CourseNotFound = new(nameof(CourseNotFound));
    public static ResponseStatus CourseFull = new(nameof(CourseFull));
    #endregion

    #region Discounts
    public static ResponseStatus DiscountNotFound = new(nameof(DiscountNotFound));
    public static ResponseStatus DiscountExpired = new(nameof(DiscountExpired));
    #endregion

    #region Events
    public static ResponseStatus EventNotFound = new(nameof(EventNotFound));
    public static ResponseStatus EventCancelled = new(nameof(EventCancelled));
    public static ResponseStatus EventConflict = new(nameof(EventConflict));
    #endregion

    #region Live
    public static ResponseStatus LiveSessionNotFound = new(nameof(LiveSessionNotFound));
    public static ResponseStatus LiveSessionClosed = new(nameof(LiveSessionClosed));
    #endregion

    #region Media
    public static ResponseStatus MediaNotFound = new(nameof(MediaNotFound));
    public static ResponseStatus UnsupportedMediaType = new(nameof(UnsupportedMediaType));
    #endregion

    #region Notifications
    public static ResponseStatus NotificationNotFound = new(nameof(NotificationNotFound));
    #endregion

    #region Orders
    public static ResponseStatus OrderNotFound = new(nameof(OrderNotFound));
    public static ResponseStatus OrderAlreadyPaid = new(nameof(OrderAlreadyPaid));
    #endregion

    #region Organizer
    public static ResponseStatus OrganizerNotFound = new(nameof(OrganizerNotFound));
    #endregion

    #region Payments
    public static ResponseStatus PaymentFailed = new(nameof(PaymentFailed));
    public static ResponseStatus PaymentSuccessful = new(nameof(PaymentSuccessful));
    #endregion

    #region Posts
    public static ResponseStatus PostNotFound = new(nameof(PostNotFound));
    #endregion

    #region Rates
    public static ResponseStatus RateNotFound = new(nameof(RateNotFound));
    #endregion

    #region Subdomains
    public static ResponseStatus SubdomainNotAvailable = new(nameof(SubdomainNotAvailable));
    #endregion

    #region Tags
    public static ResponseStatus TagNotFound = new(nameof(TagNotFound));
    #endregion

    #region TeamManagement
    public static ResponseStatus TeamNotFound = new(nameof(TeamNotFound));
    public static ResponseStatus MemberAlreadyExists = new(nameof(MemberAlreadyExists));
    #endregion

    #region Tickets
    public static ResponseStatus TicketNotFound = new(nameof(TicketNotFound));
    public static ResponseStatus TicketClosed = new(nameof(TicketClosed));
    #endregion
}
