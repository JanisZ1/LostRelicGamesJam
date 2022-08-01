using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    private Vector3 _startScale;
    private Vector3 _enabledScale;
    private bool _scaled;
    private void Start()
    {
        _startScale = transform.localScale;
        _enabledScale = new Vector3(15, 8);
    }

    public void ChangeScale()
    {
        if (_scaled)
        {
            transform.localScale = _startScale;
            _scaled = false;
        }

        else
        {
            transform.localScale = _enabledScale;
            _scaled = true;
        }
            
    }
}
