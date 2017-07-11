namespace PokeD.Core.Data.P3D
{
    public class BattleClientData
    {
        public static implicit operator string(BattleClientData battleData) => battleData._battleData;
        public static implicit operator BattleClientData(string battleData) => new BattleClientData(battleData);

        private readonly string _battleData;
        
        public string Action => _battleData.Split('|')[0] ?? string.Empty;
        public string ActionValue => _battleData.Split('|')[1] ?? string.Empty;

        public BattleClientData(string battleData) => _battleData = battleData;
    }
}