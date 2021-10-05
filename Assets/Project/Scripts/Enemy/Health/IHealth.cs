namespace Project.Scripts.Enemy.Health
{
    public interface IHealth
    {
        void TakeDamage(float amount);
        
        void ResetHealth();

        bool IsDead();
    }
}