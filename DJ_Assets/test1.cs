using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class test1
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestLoadSceneSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestLoadSceneWithEnumeratorPasses()
        {
            SceneManager.LoadScene("DK2");
                yield return new WaitForSeconds(3);
            // Load states into player states?
            Assert.AreEqual(SceneManager.GetActiveScene().name, "DK2");
            SceneManager.LoadScene("End");
            yield return new WaitForSeconds(3);
        }
    }
}
