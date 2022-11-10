using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public void RegisterButton() {
        if (passwordInput.text.Length < 6 && passwordInput.text.Length > 0){
            messageText.text="Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail=false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in";}

    public void LoginButton() {
        if (passwordInput.text.Length < 6){
            messageText.text="Password too short!";
            return;
        }
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        messageText.text = "Logged in!";
        Debug.Log("Sucessful login/account create!");}
    
    
    void OnError(PlayFabError error) {
        if (passwordInput.text.Length != 0 || emailInput.text.Length != 0){
            messageText.text = error.ErrorMessage;
            Debug.Log(error.GenerateErrorReport()); }}


}
