using System.Collections;
using System.Collections.Generic;
using Conway;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using RangeAttribute = NUnit.Framework.RangeAttribute;

namespace Tests
{
    public class ConwayRulesTests
    {

        //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        [Test]
        public void LiveCell_LessThanTwoLiveNeighbours_Dies([Range(0, 1)] int iteration)
        {
            //Setup
            CellState currentState = CellState.Alive;
            int liveNeighbors = 1;

            //Action
            CellState result = ConwayRules.GetCellState(currentState, liveNeighbors);

            //Result
            Assert.AreEqual(CellState.Dead, result);
        }

        //Any live cell with two or three live neighbours lives on to the next generation.
        [Test]
        public void LiveCell_TwoOrThreeLiveNeighbours_Lives([Range(2, 3)] int iteration)
        {
            //Setup
            CellState currentState = CellState.Alive;
            int liveNeighbors = iteration;

            //Action
            CellState result = ConwayRules.GetCellState(currentState, liveNeighbors);

            //Result
            Assert.AreEqual(CellState.Alive, result);
        }

        //Any live cell with more than three live neighbours dies, as if by overpopulation.
        [Test]
        public void LiveCell_GreaterThanThreeLiveNeighbours_Dies([Range(4, 8)] int iteration)
        {
            //Setup
            CellState currentState = CellState.Alive;
            int liveNeighbors = iteration;

            //Action
            CellState result = ConwayRules.GetCellState(currentState, liveNeighbors);

            //Result
            Assert.AreEqual(CellState.Dead, result);
        }

        //Any live cell with more than three live neighbours dies, as if by overpopulation.
        [Test]
        public void Dead_LessThanThreeLiveNeighbours_Dies([Range(0, 2)] int iteration)
        {
            //Setup
            CellState currentState = CellState.Dead;
            int liveNeighbors = iteration;

            //Action
            CellState result = ConwayRules.GetCellState(currentState, liveNeighbors);

            //Result
            Assert.AreEqual(CellState.Dead, result);
        }

        //Any live cell with more than three live neighbours dies, as if by overpopulation.
        [Test]
        public void Dead_GreaterThanThreeLiveNeighbours_Dies([Range(4, 8)] int iteration)
        {
            //Setup
            CellState currentState = CellState.Dead;
            int liveNeighbors = iteration;

            //Action
            CellState result = ConwayRules.GetCellState(currentState, liveNeighbors);

            //Result
            Assert.AreEqual(CellState.Dead, result);
        }

        //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        [Test]
        public void DeadCell_ExactlyThreeLiveNeighbours_Lives()
        {
            //Setup
            CellState currentState = CellState.Dead;
            int liveNeighbors = 3;

            //Action
            CellState result = ConwayRules.GetCellState(currentState, liveNeighbors);

            //Result
            Assert.AreEqual(CellState.Alive, result);
        }


    }
}
