
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishSolver.Core.Domain
{
    public sealed class FishGrid
    {
        public FishGrid(int dimension, IEnumerable<FishPiece> pieces)
        {
            _slots = new PieceSlot[dimension, dimension];

            for (var x = 0; x < dimension;  ++x)
            for (var y = 0; y < dimension; ++y)
            {
                _slots[x, y] = new PieceSlot(pieces.ToArray());
            }
        }

        private FishGrid(PieceSlot[,] slots)
        {
            _slots = new PieceSlot[slots.GetLength(0), slots.GetLength(1)];

            for (var x = 0; x < slots.GetLength(0); ++x)
            for (var y = 0; y < slots.GetLength(1); ++y)
            {
                _slots[x, y] = slots[x, y].Clone();
            }
        }

        public IEnumerable<PieceSlot> AllSlots
        {
            get
            {
                for (var x = 0; x < _slots.GetLength(0); ++x)
                for (var y = 0; y < _slots.GetLength(1); ++y)
                {
                    yield return _slots[x, y];
                }
            }
        }

        public IEnumerable<PieceSlot> GetCenterRelatedSlots(PieceSlot slot)
        {
            var (x, y) = GetCoordinates(slot);

            for (var x2 = 0; x2 < _slots.GetLength(0); ++x2)
            {
                if (x2 != x) yield return _slots[x2, y];
            }

            for (var y2 = 0; y2 < _slots.GetLength(1); ++y2)
            {
                if (y2 != y) yield return _slots[x, y2];
            }

            if (x == y)
            {
                for (int index = 0; index < _slots.GetLength(0); ++index)
                {
                    if (x != index) yield return _slots[index, index];
                }
            }

            if (x + y == _slots.GetLength(0))
            {
                for (var x2 = 0; x2 < _slots.GetLength(0); ++x2)
                for (var y2 = _slots.GetLength(1) - 1; y2 >= 0 ; --y2)
                {
                    if (x != x2 && y != y2) yield return _slots[x, y];
                }
            }
        }

        public (PieceSlot above,
                PieceSlot right,
                PieceSlot below,
                PieceSlot left) GetSurrounding(PieceSlot slot)
        {
            var (x, y) = GetCoordinates(slot);

            PieceSlot above = null, right = null, below = null, left = null;

            if (y != 0) above = _slots[x, y - 1];
            if (x != 0) left  = _slots[x - 1, y];

            if (y < _slots.GetLength(1) - 1) below = _slots[x, y + 1];
            if (x < _slots.GetLength(0) - 1) right = _slots[x + 1, y];

            return (above, right, below, left); 
        }

        public bool IsPossible => AllSlots.All(s => s.IsPossible);

        public bool IsSolution => AllSlots.All(s => s.Single != null);

        public FishGrid Clone() => new FishGrid(_slots);

        private (int x, int y) GetCoordinates(PieceSlot slot)
        {
            for (var x = 0; x < _slots.GetLength(0); ++x)
            for (var y = 0; y < _slots.GetLength(1); ++y)
            {
                if (ReferenceEquals(_slots[x, y], slot))
                {
                    return (x, y);
                }
            }

            throw new ArgumentException("Slot doesn't exist in grid",
                                        nameof(slot));
        }

        private readonly PieceSlot[,] _slots;
    }
}