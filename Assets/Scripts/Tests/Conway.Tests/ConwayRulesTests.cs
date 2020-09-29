using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ConwayRulesTests
    {

        //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        [Test]
        public void LiveCell_LessThanTwoLiveNeighbours_Dies()
        {
            
        }

        //Any live cell with two or three live neighbours lives on to the next generation.
        [Test]
        public void LiveCell_TwoOrThreeLiveNeighbours_Lives()
        {

        }

        //Any live cell with more than three live neighbours dies, as if by overpopulation.
        [Test]
        public void LiveCell_GreaterThanThreeLiveNeighbours_Dies()
        {

        }

        //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        [Test]
        public void DeadCell_ExactlyThreeLiveNeighbours_Lives()
        {

        }
    }
}
