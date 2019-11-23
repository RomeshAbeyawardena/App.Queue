using App.Queue.Domains.Enumerations;
using Shared.Services.Builders;
using System;
using Shared.Domains;
using System.Linq.Expressions;
using Shared.Contracts.Builders;

namespace App.Queue.Services.QueryBuilder
{
    public class QueueItemStatusQueryBuilder : IQueryBuilder<Domains.QueueItem, QueueItemStatusType>
    {
        public Expression<Func<Domains.QueueItem, bool>> GetExpression(QueueItemStatusType? queueItemStatusType)
        {
            var queueItemExpressionBuilder = ExpressionBuilder.Create();

            if (queueItemStatusType.HasValue)
            {
                switch (queueItemStatusType.Value)
                {
                    case QueueItemStatusType.Completed:
                        queueItemExpressionBuilder
                            .Not(nameof(Domains.QueueItem.Completed), ExpressionComparer.IsNull);
                        break;
                    case QueueItemStatusType.Failed:
                        queueItemExpressionBuilder
                            .And(nameof(Domains.QueueItem.Completed), ExpressionComparer.IsNull)
                            .Not(nameof(Domains.QueueItem.LastAttempted), ExpressionComparer.IsNull);
                        break;
                    case QueueItemStatusType.Pending:
                        queueItemExpressionBuilder
                            .And(nameof(Domains.QueueItem.Completed), ExpressionComparer.IsNull)
                            .And(nameof(Domains.QueueItem.LastAttempted), ExpressionComparer.IsNull);
                        break;
                }
            }

            return queueItemExpressionBuilder.ToExpression<Domains.QueueItem>();
        }
    }
}
