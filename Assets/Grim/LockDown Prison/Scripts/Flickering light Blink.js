var flickering : boolean = true;
 
function Start() {
        flickerLight();
}
 
function Update () {
 
}
 
function flickerLight() {
 
        while(flickering) {
                yield WaitForSeconds(1);
                gameObject.GetComponent.<Light>().intensity += 8;
                yield WaitForSeconds(1);
                gameObject.GetComponent.<Light>().intensity = 0;
        }
}