﻿using EventModular.Shared.Enums.Post;

namespace EventModular.Shared.Dtos.Posts;
    public class PostRequestDto
    {
    public PublishStatus PublishStatus { get; set; }
    public bool IsSchedulingPublish { get; set; }
    public DateTimeOffset? PublishOn { get; set; }
    public Visibility Visibility { get; set; }
    public PostFormat PostFormat { get; set; }
    public PostType PostType { get; set; }
    public string Password { get; set; }
    public int? Order { get; set; }
    public Guid? ParentId { get; set; }
    public PostShortDto Parent { get; set; }
    public Guid WriterId { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsCommentsAllowed { get; set; }
    public bool IsAllowPinbacks { get; set; }
    public int Revision { get; set; }
    public int CommentCount { get; set; }
    public int ViewCount { get; set; }
    public int RevisionCount { get; set; }

    public List<PostLocalizationDto>? Localizations { get; set; }
    }

    public class PostLocalizationDto
    {
        public string Key { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
    }
