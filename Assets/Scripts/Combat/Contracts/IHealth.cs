namespace Combat.Contracts
{
    public interface IHealth
    {
        int Current { get; }
        bool IsDead { get; }

        void TakeDamage(int amount);
    }
}