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
        public static CellState GetCellState(CellState currentState, int liveNeighbors)
        {
            switch (currentState)
            {
                case CellState.Alive:
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                    {
                        return CellState.Dead;
                    }
                    break;
                case CellState.Dead:
                    if (liveNeighbors == 3)
                    {
                        return CellState.Alive;
                    }
                    break;
            }
            return currentState;
        }
    }
}
