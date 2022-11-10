using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    //[Header("UI")]
    //public Text messageText;
    //public InputField emailInput;
    //public InputField passwordInput;
//
    //public void RegisterButton() {
    //    var request = new RegisterPlayFabUserRequest {
    //        Email = emailInput.text,
   //         Password = passwordInput.text,
   //         RequireBothUsernameAndEmail=false,
   //     };
   //     PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
  //  }
  //   
  //  void OnRegisterSuccess(RegisterPlayFabUserResult result) {
  //      messageText.text = "Registered and logged in";}


    void Start(){
        Login();}
    void Login() {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);}
    void OnSuccess(LoginResult result) {
        Debug.Log("Sucessful login/account create!");}
    void OnError(PlayFabError error) {
        Debug.Log("Error while logggin in/creating account!");
        Debug.Log(error.GenerateErrorReport()); }

}
