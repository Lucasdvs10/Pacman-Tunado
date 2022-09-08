namespace UnitTests {
    public class LifeController {
        private int _initialLifeAmount;
        private int _currentLifeAmount;
        
        public int GetCurrentLife() => _currentLifeAmount;
        public void ApplyDamage(int damageAmount) => _currentLifeAmount -= damageAmount;
        
        public LifeController(int initialLifeAmount) {
            _initialLifeAmount = initialLifeAmount;
            _currentLifeAmount = _initialLifeAmount;
        }
    }
}