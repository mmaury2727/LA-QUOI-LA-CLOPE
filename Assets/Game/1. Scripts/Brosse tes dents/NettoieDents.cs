using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NettoieDents : MonoBehaviour
{
    public Text m_Text;
    [SerializeField]


    private ImageAvecCoordonnees[] tabImgWithCoord;

    private float[] dentX = {53f, 68f, 86f, 110f, 132f, 148f, 48f, 58f, 70f, 89f, 111f, 131f, 142f, 155f};
    private float[] dentY = {165f, 165f, 162f, 162f, 165f, 165f, 140f, 139f, 135f, 131f, 131f, 135f, 138f, 140f};

    private bool canClean = true;


    //[SerializeField] GameObject[] tabImages;
    [SerializeField] GameObject doigt;


    private void Start()
    {
        /*tabImgWithCoord = new ImageAvecCoordonnees[tabImages.Length];
        int counter = 0;
        //print(tabImages.Length);
        foreach (GameObject img in tabImages)
        {
             tabImgWithCoord[counter] = new ImageAvecCoordonnees(img, CalcPosition(img)[0], CalcPosition(img)[1]);
             //print(tabImgWithCoord[counter].X + " " + tabImgWithCoord[counter].Y);
             counter++; 

            tabImgWithCoord[counter] = new ImageAvecCoordonnees(img, dentX[counter], dentY[counter]);
            //print(tabImgWithCoord[counter].X + " " + tabImgWithCoord[counter].Y);
            counter++;

        }*/
    }



    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            m_Text.text = "Touch Position : " + touch.position;

            doigt.transform.position = new Vector3(getXDoigtCoord(touch.position.x), getYDoigtCoord(touch.position.y), doigt.transform.position.z);
            //print(doigt.transform.position);

            int counter = 0;

            /*foreach (GameObject dent in tabImages)
            {
                if ((tabImgWithCoord[counter].X - 15 <= touch.position.x && touch.position.x <= tabImgWithCoord[counter].X + 15) && 
                    (tabImgWithCoord[counter].Y - 30 <= touch.position.y && touch.position.y <= tabImgWithCoord[counter].Y + 30))
                {
                    if (tabImgWithCoord[counter].Difficulty != 3 && canClean)
                    {
                        canClean = false;
                        StartCoroutine("CanClean");
                        tabImgWithCoord[counter].Difficulty++;
                        tabImgWithCoord[counter].Alpha -= 0.3f;
                        dent.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, tabImgWithCoord[counter].Alpha); 
                    }
                    else if (canClean) {
                        canClean = false;
                        StartCoroutine("CanClean");
                        dent.gameObject.SetActive(false); 
                    }
                    
                }
                counter++;
            }*/

        }
        else
        {
            m_Text.text = "No touch contacts";
        }
    }



    float[] CalcPosition(GameObject dent)
    {
        float[] positionImg = new float[2];

        positionImg[0] = dent.transform.position.x; // ptet ça a modif 
        positionImg[1] = dent.transform.position.y;

        return positionImg;
    }

    bool IsOnDirt(float xImg, float yImg, float xPointer, float yPointer)
    {
        if ((xPointer - 10 <= xImg || xImg <= xPointer + 10) && (yPointer - 10 <= yImg || yImg <= yPointer + 10))
        {
            return true;
        }
        return false;
    }

    float getXDoigtCoord(float coord)
    {
        if (coord >= 540)
        {
            return (coord - 540) * 5.7f / 540f;
        } else { return (coord - 540) * 5.7f / 540f; }
    }

    float getYDoigtCoord(float coord)
    {
        if(coord <= 1200) { return (coord - 864) * 9f / 864f; }
        return doigt.transform.position.y;
    }

    IEnumerator CanClean()
    {
        yield return new WaitForSeconds(0.1f);
        canClean = true;
    }
}

public class ImageAvecCoordonnees
{
    public GameObject Dent { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Difficulty { get; set; }
    //public float Alpha { get; set; }

    public ImageAvecCoordonnees(GameObject dent, float x, float y, int difficulty = 0, int alpha = 1)
    {
        Dent = dent;
        X = x;
        Y = y;
        Difficulty = difficulty;
        //Alpha = alpha;

    }
}


/*using UnityEngine;

public class TouchColliderDetection : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            // The pos of the touch on the screen
            Vector2 vTouchPos = Input.GetTouch(0).position;

            // The ray to the touched object in the world
            Ray ray = Camera.main.ScreenPointToRay(vTouchPos);

            // Your raycast handling
            RaycastHit vHit;
            if (Physics.Raycast(ray.origin, ray.direction, out vHit))
            {
                if (vHit.transform.tag == "Player")
                {
                    Destroy(vHit.collider.gameObject);
                }
            }
        }
    }


}*/
