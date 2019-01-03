using System.Collections.Generic;

using FishSolver.Core.Domain;
using FishSolver.Core.Domain.FishTypes;

using C = FishSolver.Core.Domain.FishTypes.CenterFishType;
using V = FishSolver.Core.Domain.FishTypes.VerticalFishType;
using H = FishSolver.Core.Domain.FishTypes.HorizontalFishType;

namespace FishSolver.Core
{
    public static class Defaults
    {
        public static IEnumerable<FishPiece> FishPieces => new []
        {
            new FishPiece(C.A, V.A, H.B, V.D, H.A),
            new FishPiece(C.B, V.A, H.C, V.E, H.B),
            new FishPiece(C.E, V.E, H.A, V.B, H.D),
            new FishPiece(C.A, V.D, H.D, V.B, H.A),
            new FishPiece(C.F, V.D, H.E, V.A, H.A),
            new FishPiece(C.E, V.E, H.A, V.A, H.C),
            new FishPiece(C.F, V.D, H.A, V.E, H.D),
            new FishPiece(C.F, V.C, H.B, V.E, H.D),
            new FishPiece(C.F, V.D, H.D, V.E, H.A),
            new FishPiece(C.B, V.C, H.B, V.D, H.D),
            new FishPiece(C.D, V.A, H.C, V.C, H.B),
            new FishPiece(C.A, V.E, H.A, V.A, H.B),
            new FishPiece(C.B, V.D, H.D, V.E, H.B),
            new FishPiece(C.E, V.A, H.A, V.D, H.B),
            new FishPiece(C.F, V.A, H.E, V.D, H.A),
            new FishPiece(C.C, V.A, H.E, V.C, H.B),
            new FishPiece(C.D, V.A, H.C, V.E, H.A),
            new FishPiece(C.A, V.B, H.D, V.C, H.E),
            new FishPiece(C.E, V.B, H.D, V.E, H.C),
            new FishPiece(C.D, V.E, H.C, V.A, H.B),
            new FishPiece(C.E, V.C, H.D, V.D, H.B),
            new FishPiece(C.C, V.E, H.B, V.D, H.D),
            new FishPiece(C.C, V.C, H.D, V.E, H.C),
            new FishPiece(C.A, V.B, H.E, V.A, H.C),
            new FishPiece(C.B, V.E, H.B, V.A, H.A),
            new FishPiece(C.C, V.D, H.D, V.B, H.E),
            new FishPiece(C.A, V.A, H.B, V.C, H.E),
            new FishPiece(C.C, V.E, H.B, V.A, H.C),
            new FishPiece(C.D, V.A, H.A, V.B, H.E),
            new FishPiece(C.E, V.C, H.E, V.A, H.C),
            new FishPiece(C.B, V.C, H.C, V.E, H.D),
            new FishPiece(C.C, V.A, H.C, V.C, H.B),
            new FishPiece(C.D, V.E, H.C, V.A, H.A),
            new FishPiece(C.D, V.E, H.C, V.C, H.D),
            new FishPiece(C.B, V.A, H.B, V.D, H.E),
            new FishPiece(C.F, V.E, H.B, V.C, H.D)
        };
    }
}
