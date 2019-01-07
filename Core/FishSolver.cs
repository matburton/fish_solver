
using System.Collections.Generic;
using System.Linq;

using FishSolver.Core.Domain;

namespace FishSolver.Core
{
    public sealed class FishSolver
    {
        public FishGrid Solve(FishGrid fishGrid)
        {
            var gridQueue = new Queue<FishGrid>();

            return null;
        }

        private static void RemovePossiblePiece(FishGrid fishGrid,
                                                (int x, int y) c,
                                                FishPiece fishPiece)
        {
            // TODO
        }

        private static (FishGrid leapOfFaith, FishGrid remainder) Split
            (FishGrid fishGrid)
        {
            var (chosenCoordinates, chosenSlot) = fishGrid.AllCoordinates
                .Select(c => (c, slot: fishGrid.GetSlot(c)))
                .Where(t => t.slot.Single == null)
                .OrderBy(t => t.slot.PossiblePieces.Count())
                .First();

            var leapOfFaith = fishGrid.Clone();

            var leadOfFaithSlot = leapOfFaith.GetSlot(chosenCoordinates);

            var chosenPiece = leadOfFaithSlot.PossiblePieces.First();

            leadOfFaithSlot.PossiblePieces
                           .Skip(1)
                           .ToList()
                           .ForEach(leadOfFaithSlot.RemovePiece);

            leapOfFaith.AllCoordinates
                .Where(c => c != chosenCoordinates)
                .Select(c => (c, slot: fishGrid.GetSlot(c)))
                .ToList()
                .ForEach(t => RemovePossiblePiece(leapOfFaith, t.c, chosenPiece));
            var remainder = fishGrid.Clone();

            RemovePossiblePiece(remainder, chosenCoordinates, chosenPiece);

            return (leapOfFaith, remainder);
        }
    }
}