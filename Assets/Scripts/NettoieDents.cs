using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NettoieDents : MonoBehaviour
{
    public Text m_Text;

    private ImageAvecCoordonnees[] tabImgWithCoord;

    [SerializeField] Image[] tabImages;


    private void Start()
    {
        tabImgWithCoord = new ImageAvecCoordonnees[tabImages.Length];
        int counter = 0;
        foreach (Image img in tabImages){
            tabImgWithCoord[counter] = new ImageAvecCoordonnees(img, CalcPosition(img)[0], CalcPosition(img)[1]);
            print(tabImgWithCoord[counter].X + " "+ tabImgWithCoord[counter].Y);
            counter++;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            m_Text.text = "Touch Position : " + touch.position;

            foreach (Image img in tabImages)
            {
                if ((img.transform.position.x - 30 <= touch.position.x && touch.position.x <= img.transform.position.x + 30) && (img.transform.position.x - 30 <= touch.position.x && touch.position.x <= img.transform.position.x + 30))
                {
                    img.gameObject.SetActive(false);
                }
            }

        }
        else
        {
            m_Text.text = "No touch contacts";
        }
    }

    float[] CalcPosition(Image img)
    {
        float[] positionImg = new float[2];

        positionImg[0] = img.transform.position.x + 960;
        positionImg[1] = img.transform.position.y + 540;

        return positionImg;
    }

}

public class ImageAvecCoordonnees
{
    public Image Image { get; set; }
    public float X { get; set; }
    public float Y { get; set; }

    public ImageAvecCoordonnees(Image image, float x, float y)
    {
        Image = image;
        X = x;
        Y = y;
    }
}

