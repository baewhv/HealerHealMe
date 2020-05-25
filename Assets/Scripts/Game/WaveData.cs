
public class WaveData
{
    public int waveNum = 0;
    public int spawnMonsterCount = 0;

    public WaveData()
    {

    }

    public WaveData(int _waveNum, int _spawnMonsterCount)
    {
        waveNum = _waveNum;
        spawnMonsterCount = _spawnMonsterCount;
    }

    public void SetData(int _waveNum, int _spawnMonsterCount)
    {
        waveNum = _waveNum;
        spawnMonsterCount = _spawnMonsterCount;
    }
}
