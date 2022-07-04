using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyutlandirma : MonoBehaviour
{
    #region tanimlamalar
    /// <summary>
    /// burada yazilan deðerler küpümüzün scale deðerlerinin min 
    /// ve max deðerleridir.
    /// 
    /// X ve Y kordinatlarýnda büyümeleri yapacaðýz fakat z eksenine
    /// dokunmayacagiz.
    /// </summary>
    const float MIN = 0.3f;
    const float MAX = 2f;
    float x, y; //sadece x ve y degisecegi icin bu degerleri aldim. z almadim
    Vector3 son_konum;
    bool basilma = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Ayarla();
    }
    /// <summary>
    /// farenin son konumu ile guncel konumunu karsilastirmam lazim ki 
    /// büyütme mi yaptik kücültmemi yaptik bilelim. 
    /// 
    /// </summary>
    void Ayarla()
    {
        if (Input.GetMouseButton(0)) // farenin sol tusuna basili tutuyorsak
        {
            if (basilma)
            {
                son_konum = Input.mousePosition;
                basilma= true;
                return;
            }
            // guncel fare konumu olan mousePosition.y'den basýlmaya baþladigi andaki
            // y konumunu hesaplayarak buyutme veya kucultme yapacagiz
            float fark = Input.mousePosition.y - son_konum.y;
            if (fark > 0)
            {
                /*
                 fark deðeri pozitif ise yukari yönlü bir gidis vardýr 
                 yani kullanici x degerini kucultmek y degerini buyutmek istiyor demektir                             
                 */
                x -= Time.deltaTime * fark; 
                // x degerini fark degerinin büyüklügüne göre hýzla kucultme
                y +=Time.deltaTime * fark;
            }
            else
            {
                x -=Time.deltaTime * fark;
                y +=Time.deltaTime * fark;
            }
            son_konum = Input.mousePosition;
            x=Mathf.Clamp(x, MIN, MAX);
            y=Mathf.Clamp(y, MIN, MAX);
            transform.localScale=new Vector3((float)x, (float)y, 1);
            transform.position = new Vector3(0,y/2,transform.position.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
           basilma = true;
        }
        
    }
}
