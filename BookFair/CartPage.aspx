<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="CartPage.aspx.cs"
Inherits="BookFair.CartPage" Async="true" ViewStateMode="Enabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .cutsome-component-container {
      padding: 10px, 20px, 10px, 20px;
      display: flex;
      flex-direction: column;
      gap: 10px;
      align-items: center;
    }
    .page-redirect-container {
      width: 260px;
      display: flex;
      flex-direction: row;
      align-items: center;
      margin-bottom: 30px;
      padding: 20px;
    }
    .btn-option-page-redirect {
      background-color: transparent;
    }

    .label-page-redirect {
      font-size: 15px;
    }

    .order-btn {
      border-radius: 15px;
      height: 40px;
      margin-top: 20px;
      margin-bottom: 20px;
      float: right;
      width: 150px !important;
      margin-right: 25px;
    }

    #ASPxPopupControl1_PW0,
    .pop-up-window,
    .pop-up-window-container {
      left: 50% !important;
      top: 50% !important;
      transform: translateX(-50%);
      width: 400px;
      height: 100px;
    }

    .pop-up-window .dxpc-window {
      position: fixed;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
    }

    .pop-up-window-container {
      position: absolute;
    }

    #ContentPopUpWindow {
      left: 50% !important;
      top: 50% !important;
      transform: translateX(-50%);
    }
  </style>

  <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="100%">
    <PanelCollection>
      <dx:PanelContent>
        <div class="page-redirect-container">
          <dx:ASPxButton
            ID="ASPxButtonBack"
            UseSubmitBehavior="false"
            CssClass="btn-option-page-redirect"
            runat="server"
            OnClick="Goback_ButtonClick"
            Image-Url="~/utlis/Images/iconBack.svg"
            Image-Width="50px"
          >
            <Image Width="50px" Url="~/utlis/Images/iconBack.svg"></Image>
          </dx:ASPxButton>
          <dx:aspxlabel
            ID="labelPageRedirect"
            CssClass="label-page-redirect"
            Text="Go Back To Home Page"
            runat="server"
          ></dx:aspxlabel>
        </div>
        <dx:ASPxButton
          ID="ASPxButtonMakeOrder"
          runat="server"
          Text="Make Order"
          OnClick="ASPxButtonMakeOrder_Click"
          CssClass="order-btn"
          UseSubmitBehavior="false"
        ></dx:ASPxButton>

        <dx:ASPxPanel
          ID="PanleCustomeContainer"
          runat="server"
          CssClass="cutsome-component-container"
          Width="100%"
        >
          <PanelCollection>
            <dx:PanelContent> </dx:PanelContent>
          </PanelCollection>
        </dx:ASPxPanel>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>

  <dx:aspxpopupcontrol
    ID="ASPxPopupControl1"
    CssClass="pop-up-window"
    runat="server"
    CloseAction="CloseButton"
    Left="50"
    Top="50"
    Width="400px"
    Height="100px"
    ContentStyle-HorizontalAlign="Center"
    ContentStyle-VerticalAlign="Middle"
    ContentStyle-Wrap="True"
    ClientIDMode="Static"
    PopupElementID="PopUpWindowElement"
    ShowOnPageLoad="True"
  >
    <windows>
      <dx:popupwindow
        CloseAction="CloseButton"
        ScrollBars="None"
        ShowCloseButton="True"
        ShowFooter="False"
        ShowHeader="True"
        ShowMaximizeButton="False"
        ShowOnPageLoad="True"
        ShowPinButton="False"
        ShowRefreshButton="False"
        Width="100%"
        Height="100%"
        HeaderText="*"
      >
        <contentstyle HorizontalAlign="Center" VerticalAlign="Middle">
          <paddings Padding="20px" />
        </contentstyle>
        <contentcollection>
          <dx:popupcontrolcontentcontrol runat="server">
          </dx:popupcontrolcontentcontrol>
        </contentcollection>
      </dx:popupwindow>
    </windows>

    <contentstyle
      HorizontalAlign="Center"
      VerticalAlign="Middle"
      Wrap="True"
    ></contentstyle>
    <contentcollection>
      <dx:popupcontrolcontentcontrol runat="server">
      </dx:popupcontrolcontentcontrol>
    </contentcollection>
  </dx:aspxpopupcontrol>
</asp:Content>
