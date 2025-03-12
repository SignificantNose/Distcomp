using System;
using Application.Abstractions;
using Domain.Mappers;
using Domain.Models;
using Domain.Projections;
using Domain.Repositories;
using Shared.Domain;

namespace Application.Features.Reaction.Commands;

public class UpdateReactionCommandHandler
    : ICommandHandler<UpdateReactionCommand, ReactionMongoProjection>
{
    private readonly IReactionRepository _reactionRepository;

    public UpdateReactionCommandHandler(IReactionRepository reactionRepository)
    {
        _reactionRepository = reactionRepository;
    }

    public async Task<Result<ReactionMongoProjection>> Handle(
        UpdateReactionCommand request,
        CancellationToken cancellationToken
    )
    {
        var resultReaction = await _reactionRepository.UpdateReaction(
            new ReactionMongoModel
            {
                Id = request.id.ToString(),
                TweetId = request.tweetId,
                Content = request.content,
            }
        );

        if (!resultReaction.IsSuccess)
        {
            return Result.Failure<ReactionMongoProjection>(resultReaction.Error);
        }

        return resultReaction.Value.ToReactionMongoProjection();
    }
}
