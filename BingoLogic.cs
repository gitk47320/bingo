using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;


public class BingoLogic
{
    public int MAX_NUM = 75;
    private int _bingocount = 0;
    //ビンゴマシーンで表示する番号１～７５をリストで定義する
    private List<int> _numdisplay = new List<int>()
        {
              1,2,3,4,5,6,7,8,9,10,
            11,12,13,14,15,16,17,
            18,19,20,21,22,23,24,
            25,26,27,28,29,30,31,
            32,33,34,35,36,37,38,
            39,40,41,42,43,44,45,
            46,47,48,49,50,51,52,
            53,54,55,56,57,58,59,
            60,61,62,63,64,65,66,
            67,68,69,70,71,72,73,
            74,75
        };
    //ビンゴマシーンで表示後の番号を格納しておく
    private List<int> _numlog = new List<int>();

    //リストnumdisplayのgetterとsetter
    public List<int> numdisplay
    {
        get
        {
            return this._numdisplay;
        }
    }

    //リストnumdlogsのgetter
    public List<int> numlog
    {
        get
        {
            return this._numlog;
        }
    }

    //リストnumdlogsのgetterとsetter
    public int  bingocount
    {
        get
        {
            return this._bingocount;
        }
        set
        {
            _bingocount = value;
        }
    }

    public BingoLogic()
	{
       
	}

    public void SetNumdisplay()
    {
        for (int i = 0; i < MAX_NUM; i++)
        {
            _numdisplay[i] = i + 1;
        }
    }

    //乱数を生成する
    //引数：なし
    public int BingoRandom(int seed)
    {
        //ランダムの乱数を返す
        //シード値としてシステム時刻を用いるため、引数は与えない
        System.Random r = new System.Random(seed);

        //0以上MAX_NUM未満の乱数を整数で返す
        return r.Next(0,MAX_NUM);
    }

    //ビンゴの抽選番号を算出する
    //numdisplayリストから無作為に抽出する
    //引数：なし
    public int Numdisplay()
    {
        //numindexはBingoRandomでランダムに算出される
        int numindex = BingoRandom(System.Environment.TickCount);
        //numdisplayリストからnumindex要素をビンゴの抽選番号とする
        int display = _numdisplay[numindex];
        //2回目のゲーム以降は、すでに選ばれた抽選番号以外のものを採用する
        if (_bingocount > 0)
        {
            //既出の抽選番号の要素は-1であるため、これ以外が出るまで抽選番号を算出し続ける
            while(display == -1)
            {
                //乱数が同じにならないようにseed値に変化を持たせる
                numindex = BingoRandom(System.Environment.TickCount * 1000);
                display = _numdisplay[numindex];
            }
        }
        else
        {
            //1回目のゲーム時は既出の抽選番号は存在しないため上記の分岐に入らない
        }

        //既出の抽選番号として今回の番号を別のnumlogリストに持たせる
        _numlog.Add(display);
        //既出のインデックスの要素は-1を代入する
        _numdisplay[numindex] = -1;
        return display;
    }

    //ビンゴゲームをはじめから開始するために
    //各種データをクリアおよび初期化する。
    public void BingoInit()
    {
        SetNumdisplay();
        _numlog.Clear();
        _bingocount = 0;
    }
}
