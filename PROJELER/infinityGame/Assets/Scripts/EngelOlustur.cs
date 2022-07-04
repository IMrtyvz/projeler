using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelOlustur : MonoBehaviour
{
    //olusacak engellerin min ve max degerleri 
    const float MIN = 0.3f;
    const float MAX = 2f;
    const float MAX_MIN = MAX - MIN;
    const float hataPayi=.3f;
    // Start is called before the first frame update
    void Start()
    {
        Engel_Olustur();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Engel_Olustur()
    {
        GameObject engel_objesi = new GameObject("Engel");
        //engel adinda bos bir obje olusturduk.
        // aralik degerini belirlemeliyiz
        float aralik = Random.Range(0,MAX_MIN);
        float x = aralik + MIN;
        float y = MAX - aralik + hataPayi;

        // sol duvari olusturalim
        Vector3 scal = new Vector3(2f - x / 2, y, 1f);
        Vector3 pos = new Vector3(-2f + scal.x / 2, scal.y / 2, 0);
        Duvar_Olustur(scal, pos, engel_objesi.transform);

        // sag duvar olusturalim
        pos=new Vector3(2f-scal.x / 2, scal.y/2, 0);
        Duvar_Olustur(scal, pos, engel_objesi.transform);

        // ust duvari olusturalim
        scal = new Vector3(4f, 2f, 1f);
        // ust duvarda y ye göre newleyecegiz
        pos = new Vector3(0f, y + .5f, 0f);
        Duvar_Olustur(scal, pos, engel_objesi.transform);
    }
    public void Duvar_Olustur(Vector3 buyukluk,Vector3 konum, Transform parent)
    {
        // duvarlarýmýz solda sagda ve yukarda olacak arada kalan boþluktan küpümüz
        // gececek
        GameObject duvar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        duvar.transform.localScale = buyukluk;
        duvar.transform.localPosition= konum;
        duvar.transform.parent = parent;
    }
}
