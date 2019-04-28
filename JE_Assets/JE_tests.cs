using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JE_tests
    {
        private int streak;
        private int missCounter;
        private int score;
        private int hitNumber;

        // A Test behaves as an ordinary method
        [Test]
        public void TestPointsNoStreak()
        {
            reset();
            // Use the Assert class to test conditions
            for (int i = 0; i < 1000; i++)
            {
                hit();
                Miss();
            }
            Assert.AreEqual(score, 1000);
        }
        [Test]
        public void TestPointsWithStreak()
        {
            reset();
            // Use the Assert class to test conditions
            for (int i = 0; i < 1000; i++)
            {
                hit();
                hit();
                hit();
                hit();
                hit();
                Miss();
            }
            Assert.AreEqual(6000 ,score);
            Assert.AreEqual(5000, hitNumber);
        }
        [Test]
        public void TestStreak()
        {
            reset();
            // Use the Assert class to test conditions
            for (int i = 0; i < 500; i++)
            {
                hit();
            }
            Assert.AreEqual(500, streak);
            Miss();
            Assert.AreEqual(0, streak);
        }


        public void reset()
        {
            streak = 0;
            score = 0;
            hitNumber = 0;
            missCounter = 0;
        }
        public void Miss()
        {
            streak = 0;
            missCounter++;
        }
        public void hit()
        {
            streak++;
            hitNumber++;
            score += 1 + streak / 5;
        }
    }
}
