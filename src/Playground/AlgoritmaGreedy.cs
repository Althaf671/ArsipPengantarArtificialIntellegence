///<summary>
///
///     Program pemilihan banyak jadwal dengan level prioritas dan batas maksimum
///     
///     To-do:
///         diterima input batas maksimum misal int 10
///         lakukan iterasi untuk menemukan jadwal dengan prioritas mana saja agar
///         mencapat batas maksimum dan total solusi.
/// 
///</summary>

namespace Playground;
internal static class AlgoritmaGreedy
{
    // deklarasi output akhir dengan tipe data list dengan tipe data JadwalDanPrioritas
    private static readonly List<JadwalDanPrioritas> _outputAkhir = []; 

    // deklrasi index interator untuk menghitung urutan output
    private static int _idxNumber = 0;

    // deklrasi total prioritas untuk di iterasi
    private static int _totalPrioritas = 0;

    // method temuka jadwal tanpa return dan menerima 1 param yaitu int batas maks
    internal static void TemukanJadwal(int batasMaksimum)
    {
        // urutkan semua jadwal berdasarkan prioritas teringgi
        var temukanUrutanJadwalDariYangTertinggi = KumpulanJadwalDanLevelPrioritas
            .OrderByDescending(j => j.Prioritas) // method bawaan sistem untuk mengurutkan dari nilai tertinggi
            .ToList(); // jadikan kumpulan objek list

        //=== PRIMARY LOGIC ===//
        Console.WriteLine("");
        Console.WriteLine("//======== START PROGRAM ==========//");
        Console.WriteLine("");

        Console.WriteLine($"Berikut adalah urutan jadwal dari yang tertinggi: ");

        // masukan result dari method temukan urutan jadwal dari yang tertinggi ke dalam var jadwal
        // lalu lakukan looping denga foreach yang mengeksekusi looping while.
        foreach (var jadwal in temukanUrutanJadwalDariYangTertinggi)
        {
            // looping while akan dieksekusi jika selama _totalPrioritas value kecil sama dari input batasMaksimum tadi
            // value _totalPrioritas yang awalnya 0 akan ditambah dengan jadwal.Prioritas value, misal:
            // _totalPrioritas = 0
            // jadwal.Prioritas (anggap memasak dengan value 3) maka _totalPrioritas = 0 + 3
            // ulangi sampai mencapai batas maks
            while (_totalPrioritas + jadwal.Prioritas <= batasMaksimum) 
            {
                // masukan objek jadwal yang sedang diloop ke dalam array output akhir
                _outputAkhir.Add(jadwal);

                // assign value baru untuk _totalProritas dari hasil penambahan dari value jadwal.Prioritas yang sedang di loop
                _totalPrioritas += jadwal.Prioritas;

                // jika hasil perhitungan di dalam while untuk _totalPrioritas equals dengan batas maksimum maka berhenti
                if (_totalPrioritas == batasMaksimum)
                    break;
            }

            // jika value dari _totalPrioritas equals dengan batas maksimum maka berhenti
            if (_totalPrioritas == batasMaksimum)
                break;
        }

        // tampilkan output
        // deklrasi jadwal berisi array _outputAkhir yang seharusnya sudah berisi objek2 sesuai dengan prioritas
        foreach (var jadwal in _outputAkhir)
        {
            // tampilkan output dengan format No: 1 - Jadwal: Memasak, level prioritas: 3 dst...
            Console.WriteLine($"No: {_idxNumber++} - Jadwal: {jadwal.Jadwal}, level prioritas: {jadwal.Prioritas}");
        }
        Console.WriteLine($"Total solusi adalah: {_outputAkhir.Count}"); // hitung total solusi

        Console.WriteLine("");
        Console.WriteLine("//========== END PROGRAM ==========//");
        Console.WriteLine("");
    }

    // daftar jadwal dan masing masing prioritas di dalam array list
    private static readonly List<JadwalDanPrioritas> KumpulanJadwalDanLevelPrioritas = 
    [
        new JadwalDanPrioritas("Mencuci", 1),
        new JadwalDanPrioritas("Menyapu", 2),
        new JadwalDanPrioritas("Memasak", 3)
    ];

    // tipe data custom dengan record
    private record JadwalDanPrioritas(
        string Jadwal,
        int Prioritas
    );
}