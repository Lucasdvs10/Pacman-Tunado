using NUnit.Framework;

namespace UnitTests {
    public class Life_Should {
        private LifeController _lifeController;
        
        [SetUp]
        public void Setup_Tests() {
            _lifeController = new LifeController(3);
        }

        [Test]
        public void Should_Return_3_When_Not_Taken_Damage() {
            var currentLifeAmount = _lifeController.GetCurrentLife();
            
            Assert.AreEqual(3, currentLifeAmount);
        }

        [Test]
        public void Should_Return_1_When_Taken_2_Damage() {
            _lifeController.ApplyDamage(2);
            
            var currentLifeAmount = _lifeController.GetCurrentLife();

            Assert.AreEqual(1, currentLifeAmount);
        }
        
        [Test]
        public void Should_Return_4_When_Taken_Negative_1_Damage() {
            _lifeController.ApplyDamage(-1);
            
            var currentLifeAmount = _lifeController.GetCurrentLife();

            Assert.AreEqual(4, currentLifeAmount);
        }
        
        
    }
}