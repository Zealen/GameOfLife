using System;

namespace Conway
{
    public enum CellState
    {
        Alive,
        Dead
    }
    public class ConwayRules
    {
        public static CellState GetCellState(CellState currentState, int liveNeighbours)
        {
            switch (currentState)
            {
                case CellState.Alive:
                    if (liveNeighbours < 2 || liveNeighbours > 3)
                    {
                        return CellState.Dead;
                    }
                    break;
                case CellState.Dead:
                    if (liveNeighbours == 3)
                    {
                        return CellState.Alive;
                    }
                    break;
            }
            return currentState;
        }
    }
}
