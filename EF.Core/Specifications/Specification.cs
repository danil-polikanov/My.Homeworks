using EF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EF.Core.Specifications
{
    public class Specification<TEntity>
           where TEntity : Entity
    {
        public Expression<Func<TEntity, bool>> Expression { get; }
        public List<Expression<Func<TEntity, object>>> Сonditions { get; }

        public Func<TEntity, bool> Func => this.Expression.Compile();

        public Specification(Expression<Func<TEntity, bool>> expression, List<Expression<Func<TEntity, object>>> condition = default)
        {
            this.Expression = expression;
            this.Сonditions = condition;
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            return this.Func(entity);
        }
    }
}
