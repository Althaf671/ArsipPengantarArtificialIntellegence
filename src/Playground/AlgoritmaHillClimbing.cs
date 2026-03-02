///<summary>
///
///     Program untuk mencari harga terbaik agar mendekati target penjualan   
/// 
///     Note: program ini heavily dibantu oleh Claude dan GPT
///     
///</summary>

namespace Playground;
internal static class AlgoritmaHillClimbing
{
    private const decimal _targetPenjualan = 3500000; // set target penjualan
    private const decimal _hargaDasar = 15000; // set harga dasar untuk method helper

    // method ini akan menerima 1 param dan akan kalkulasi kan harga terbaik
    internal static void ProgramTemukanHargaDasarTerbaikUntukMencapaiTargetPenjualan(decimal hargaDasar)
    {
        // inisiasi beberapa var awal seperti terima harga awal dari input 
        decimal harga = hargaDasar;
        decimal step = 500;
        decimal target = _targetPenjualan;

        // hitung selsisih score awal
        decimal scoreSekarang = HitungSelisihDenganTarget(harga, target);

        // jalankan while loop agar dia terus mencoba mencari harga naik 500 dan turun 500
        while (true)
        {
            decimal hargaNaik = harga + step;
            decimal hargaTurun = harga - step;

            // hitung score naik dengan helper di bawah
            decimal scoreNaik = HitungSelisihDenganTarget(hargaNaik, target);

            // hitung score turun dengan helper di bawah
            decimal scoreTurun = HitungSelisihDenganTarget(hargaTurun, target);

            // jika score naik kecil dari score sekarang maka in yang lebih bagus
            if (scoreNaik < scoreSekarang)
            {
                harga = hargaNaik; // harga dasar yg cocok adalah harga naik
                scoreSekarang = scoreNaik;
            }
            // jika score turun kecil dari score sekarang maka lebih buruk
            else if (scoreTurun < scoreSekarang)
            {
                harga = hargaTurun;
                scoreSekarang = scoreTurun;
            }
            else
            {
                break; // hentikan jika statement di atas tidak true
            }
        }

        // print output
        Console.WriteLine($"Harga terbaik adalah: {harga}");
        Console.WriteLine($"Total Penjualan: {SimulasiPenjualan(harga)}");
    }

    // helper untuk mencari selisih dengan target yang menerima param harga dan target
    private static decimal HitungSelisihDenganTarget(decimal harga, decimal target)
    {
        decimal total = SimulasiPenjualan(harga); // deklarasi var total berisi result dari method simulasi penjualan
        return Math.Abs(target - total); // return absolute value dari decimal target - total
    }

    // helper untuk mensimulasikan penjualan dengan 1 input param yaitu harga
    private static decimal SimulasiPenjualan(decimal harga)
    {
        // jika harga naik customer turun, jika harga turun costumer naik
        decimal jumlahCustomer = 500 - (harga - _hargaDasar) / 100;
        if (jumlahCustomer < 0)
            jumlahCustomer = 0;

        return harga * jumlahCustomer; // total penjualan = harga x customer
    }
}