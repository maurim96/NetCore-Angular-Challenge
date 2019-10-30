using Application.Repositories;

namespace Application.UoW
{
    public interface IUnitOfWork
    {
        ICompetitionRepository CompetitionRepository { get; }
        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
        void Dispose();
    }
}
