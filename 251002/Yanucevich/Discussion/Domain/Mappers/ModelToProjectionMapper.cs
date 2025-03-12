using System;
using Domain.Models;
using Domain.Projections;

namespace Domain.Mappers;

public static class ModelToProjectionMapper
{
    public static ReactionProjection ToReactionProjection(this ReactionModel model)
    {
        return new ReactionProjection
        {
            Id = model.Id,
            TweetId = model.TweetId,
            Content = model.Content,
        };
    }

    public static ReactionMongoProjection ToReactionMongoProjection(this ReactionMongoModel model)
    {
        return new ReactionMongoProjection
        {
            Id = long.Parse(model.Id),
            TweetId = model.TweetId,
            Content = model.Content,
        };
    }
}
