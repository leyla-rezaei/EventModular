using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventModular.Server.Modules.Live.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "live");

            migrationBuilder.EnsureSchema(
                name: "localization");

            migrationBuilder.CreateTable(
                name: "LiveParticipant",
                schema: "live",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsModerator = table.Column<bool>(type: "bit", nullable: false),
                    IsMuted = table.Column<bool>(type: "bit", nullable: false),
                    IsKicked = table.Column<bool>(type: "bit", nullable: false),
                    JoinedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LeftAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveParticipant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveQuestion",
                schema: "live",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false),
                    AskedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AnsweredAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AnsweredById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveQuestionLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveQuestionLocalization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveRoom",
                schema: "live",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThumbnailMediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecordingMediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ScheduledEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ActualStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ActualEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRecorded = table.Column<bool>(type: "bit", nullable: false),
                    AllowReplay = table.Column<bool>(type: "bit", nullable: false),
                    AllowAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    RequireTicket = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    CurrentParticipants = table.Column<int>(type: "int", nullable: false),
                    AllowChat = table.Column<bool>(type: "bit", nullable: false),
                    AllowQnA = table.Column<bool>(type: "bit", nullable: false),
                    AllowPolls = table.Column<bool>(type: "bit", nullable: false),
                    AllowReactions = table.Column<bool>(type: "bit", nullable: false),
                    AllowScreenShare = table.Column<bool>(type: "bit", nullable: false),
                    AllowFileShare = table.Column<bool>(type: "bit", nullable: false),
                    IsPasswordProtected = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnableAdaptiveBitrate = table.Column<bool>(type: "bit", nullable: false),
                    EnableRecordingCloud = table.Column<bool>(type: "bit", nullable: false),
                    DefaultLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnableSubtitles = table.Column<bool>(type: "bit", nullable: false),
                    EnableSimultaneousTranslation = table.Column<bool>(type: "bit", nullable: false),
                    TotalViewCount = table.Column<int>(type: "int", nullable: false),
                    PeakConcurrentUsers = table.Column<int>(type: "int", nullable: false),
                    TotalWatchTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsMutedAll = table.Column<bool>(type: "bit", nullable: false),
                    AllowRaiseHand = table.Column<bool>(type: "bit", nullable: false),
                    AllowModeratorKick = table.Column<bool>(type: "bit", nullable: false),
                    AllowModeratorMute = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveChatMessage",
                schema: "live",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsPinned = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveChatMessage_LiveRoom_LiveRoomId",
                        column: x => x.LiveRoomId,
                        principalSchema: "live",
                        principalTable: "LiveRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivePoll",
                schema: "live",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    IsMultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivePoll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivePoll_LiveRoom_LiveRoomId",
                        column: x => x.LiveRoomId,
                        principalSchema: "live",
                        principalTable: "LiveRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiveReaction",
                schema: "live",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emoji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LiveRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveReaction_LiveRoom_LiveRoomId",
                        column: x => x.LiveRoomId,
                        principalSchema: "live",
                        principalTable: "LiveRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiveRoomLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveRoomLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveRoomLocalization_LiveRoom_LiveRoomId",
                        column: x => x.LiveRoomId,
                        principalSchema: "live",
                        principalTable: "LiveRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiveChatMessageLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveChatMessageLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveChatMessageLocalization_LiveChatMessage_LiveChatMessageId",
                        column: x => x.LiveChatMessageId,
                        principalSchema: "live",
                        principalTable: "LiveChatMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivePollLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivePollId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivePollLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivePollLocalization_LivePoll_LivePollId",
                        column: x => x.LivePollId,
                        principalSchema: "live",
                        principalTable: "LivePoll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivePollOption",
                schema: "live",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteCount = table.Column<int>(type: "int", nullable: false),
                    LivePollId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivePollOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivePollOption_LivePoll_LivePollId",
                        column: x => x.LivePollId,
                        principalSchema: "live",
                        principalTable: "LivePoll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivePollOptionLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivePollOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiveQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivePollOptionLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivePollOptionLocalization_LivePollOption_LivePollOptionId",
                        column: x => x.LivePollOptionId,
                        principalSchema: "live",
                        principalTable: "LivePollOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivePollOptionLocalization_LiveQuestion_LiveQuestionId",
                        column: x => x.LiveQuestionId,
                        principalSchema: "live",
                        principalTable: "LiveQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiveChatMessage_LiveRoomId",
                schema: "live",
                table: "LiveChatMessage",
                column: "LiveRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveChatMessageLocalization_LiveChatMessageId",
                schema: "localization",
                table: "LiveChatMessageLocalization",
                column: "LiveChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_LivePoll_LiveRoomId",
                schema: "live",
                table: "LivePoll",
                column: "LiveRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LivePollLocalization_LivePollId",
                schema: "localization",
                table: "LivePollLocalization",
                column: "LivePollId");

            migrationBuilder.CreateIndex(
                name: "IX_LivePollOption_LivePollId",
                schema: "live",
                table: "LivePollOption",
                column: "LivePollId");

            migrationBuilder.CreateIndex(
                name: "IX_LivePollOptionLocalization_LivePollOptionId",
                schema: "localization",
                table: "LivePollOptionLocalization",
                column: "LivePollOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_LivePollOptionLocalization_LiveQuestionId",
                schema: "localization",
                table: "LivePollOptionLocalization",
                column: "LiveQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveReaction_LiveRoomId",
                schema: "live",
                table: "LiveReaction",
                column: "LiveRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveRoomLocalization_LiveRoomId",
                schema: "localization",
                table: "LiveRoomLocalization",
                column: "LiveRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiveChatMessageLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "LiveParticipant",
                schema: "live");

            migrationBuilder.DropTable(
                name: "LivePollLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "LivePollOptionLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "LiveQuestionLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "LiveReaction",
                schema: "live");

            migrationBuilder.DropTable(
                name: "LiveRoomLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "LiveChatMessage",
                schema: "live");

            migrationBuilder.DropTable(
                name: "LivePollOption",
                schema: "live");

            migrationBuilder.DropTable(
                name: "LiveQuestion",
                schema: "live");

            migrationBuilder.DropTable(
                name: "LivePoll",
                schema: "live");

            migrationBuilder.DropTable(
                name: "LiveRoom",
                schema: "live");
        }
    }
}
