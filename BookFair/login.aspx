<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BookFair.login"
Async="true" %>
<asp:content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    * {
      font-family: "Concert One", "ConcertOne";

      font-size: 16px;
    }

    .error-msg {
      color: red;
    }

    .panel {
      display: flex;
      flex-direction: row;
      align-items: center;
    }

    .panel-form-login {
      height: 100%;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      gap: 10px;
    }

    .register-container {
      display: flex;
      flex-direction: row;
      align-items: center;
      gap: 5px;
    }
    .welcome-image {
      width: 150px;
    }

    .Form-Container-login {
      padding: 0;
    }

    .img-login {
      width: 100%;
    }

    .img-container {
      width: 100%;
    }

    .input-login {
      width: 100%;
      border-radius: 10px;
      height: 30px;
    }

    .btn-login {
      float: right;
      border-radius: 10px;
      margin: auto;
      background-color: #a27cff;
    }

    .hyp-register,
    .hyp-forget-pass {
      color: #f87c1d;
      width: fit-content;
      text-decoration: none;
      cursor: pointer;
      color: #a27cff;
      font-size: 20px;
    }

    .heading-login-text {
      font-size: 30px;
      color: #ff81ae;
    }

    .hyp-forget-pass {
      font-size: 18px;
    }

    .forgit-pass-container {
      float: right;
    }
  </style>

  <dx:aspxpanel ID="ASPxPanel1" runat="server" CssClass="panel" width="100%">
    <panelcollection>
      <dx:panelcontent>
        <div class="img-container">
          <dx:aspximage
            Width="100%"
            CssClass="img-login"
            ID="ASPxImage1"
            runat="server"
            ImageUrl="~/utlis/Images/Bookshop-pana.svg"
            ShowLoadingImage="true"
          >
          </dx:aspximage>
        </div>

        <dx:aspxpanel
          ID="ASPxPanel2"
          runat="server"
          CssClass="panel-form-login"
          width="100%"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:aspximage
                CssClass="welcome-image"
                ID="ASPxFormLayout1_E1"
                runat="server"
                ImageUrl="~/utlis/Images/wel.svg"
              >
              </dx:aspximage>

              <dx:aspxlabel
                ID="ASPxFormLayout1_E10"
                runat="server"
                Text="Welcome Back"
                CssClass="heading-login-text"
              >
              </dx:aspxlabel>

              <dx:aspxformlayout
                ID="ASPxFormLayout1"
                runat="server"
                Width="100%"
                ShowItemCaptionColon="False"
                CssClass="Form-container-login-input"
              >
                <items>
                  <dx:layoutgroup
                    Caption=""
                    ColSpan="1"
                    CssClass="group-component-input-container"
                    ShowCaption="False"
                  >
                    <bordertop BorderStyle="None" />
                    <border BorderStyle="None" />
                    <paddings PaddingLeft="150px" PaddingRight="150px" />
                    <groupboxstyle>
                      <border BorderStyle="None" />
                    </groupboxstyle>
                    <items>
                      <dx:layoutitem Caption="Email" ColSpan="1" Name="email">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxtextbox
                              ID="FL_email_login"
                              runat="server"
                              Placeholder="user@mail.com"
                              CssClass="input-login email-text-input-login"
                              NullText="ex@mail.com"
                              Width="100%"
                            >
                              <validationsettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                                EnableCustomValidation="True"
                              >
                                <regularexpression
                                  ErrorText="Wrong Email Format"
                                  ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$"
                                />
                                <requiredfield
                                  IsRequired="True"
                                  ErrorText="Email is required"
                                />
                              </validationsettings>
                            </dx:aspxtextbox>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                        <captionsettings VerticalAlign="Middle" />
                      </dx:layoutitem>
                      <dx:layoutitem
                        Caption="Password"
                        ColSpan="1"
                        Name="password"
                      >
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxtextbox
                              ID="FL_pass_login"
                              runat="server"
                              Password="True"
                              CssClass="input-login password-text-input-login"
                              TextMode="Password"
                              Placeholder="Enter your password"
                              Width="100%"
                              NullText="Enter A Password"
                            >
                              <validationsettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                                EnableCustomValidation="True"
                              >
                                <errorframestyle Wrap="True"> </errorframestyle>
                                <requiredfield
                                  IsRequired="True"
                                  ErrorText="Password is required"
                                />
                              </validationsettings>
                            </dx:aspxtextbox>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxbutton
                              ID="FL_B_Log"
                              runat="server"
                              CssClass="btn-login"
                              Text="Login"
                              Height="40px"
                              HorizontalAlign="Center"
                              VerticalAlign="Middle"
                              Width="150px"
                              OnClick="ASPxFormLayout1_E2_Click"
                            >
                            </dx:aspxbutton>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxvalidationsummary
                              ID="ASPxValidationSummary1"
                              runat="server"
                            >
                            </dx:aspxvalidationsummary>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>

                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxlabel
                              Text="User does not exist or password is invalid"
                              runat="server"
                              ID="ASPxLabelError"
                              CssClass="error-msg"
                              Visible="False"
                            ></dx:aspxlabel>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                    </items>
                  </dx:layoutgroup>
                </items>
              </dx:aspxformlayout>

              <div class="register-container">
                <dx:aspxlabel
                  ID="ASPxLabel1"
                  runat="server"
                  Text="Don't have an account"
                  Font-Size="20px"
                >
                </dx:aspxlabel>

                <dx:aspxhyperlink
                  ID="ASPxHyperLink1"
                  CssClass="hyp-register"
                  runat="server"
                  Text="Register"
                  NavigateUrl="~/Register.aspx"
                  ForeColor="#A27CFF"
                >
                </dx:aspxhyperlink>
              </div>

              <div class="forgit-pass-container">
                <dx:aspxhyperlink
                  ID="ASPxHyperLink2"
                  CssClass="hyp-forget-pass"
                  runat="server"
                  Text="Forget your Password"
                  NavigateUrl="~/ResetPassword.aspx"
                  ForeColor="#A27CFF"
                >
                </dx:aspxhyperlink>
              </div>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>
      </dx:panelcontent>
    </panelcollection>
  </dx:aspxpanel>
</asp:content>
