<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="OrderItemPage.aspx.cs"
Inherits="BookFair.OrderItemPage" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .custome-component-container {
      width: 100%;
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      gap: 20px;
    }
    .opt-btn {
      border-radius: 15px;
      width: 150px;
      height: 30px;
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
    .opt-btn-container {
      margin-top: 50px;
      margin-bottom: 50px;
      width: 100%;
      display: flex;
      flex-direction: row;
      justify-items: center;
      align-items: center;
      gap: 20px;
      justify-content: center;
    }
  </style>

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
      Text="Go Back To Orders Page"
      runat="server"
    ></dx:aspxlabel>
  </div>
  <dx:ASPxPanel runat="server" ID="ContainerButtonManageOrder" CssClass="opt-btn-container">
      <PanelCollection>
          <dx:PanelContent>
    <dx:ASPxButton
      ID="ASPxButtonAddItem"
      runat="server"
      Text="Add Item To The Order"
      CssClass="opt-btn order-btn"
      OnClick="ASPxButtonAddItem_Click"
    ></dx:ASPxButton>
    <dx:ASPxButton
      ID="ASPxButtonDelete"
      UseSubmitBehavior="false"
      runat="server"
      Text="Delete The Order"
      CssClass=" opt-btn order-btn"
      OnClick="ASPxButtonDelete_Click"
    ></dx:ASPxButton>
  </dx:PanelContent>
      </PanelCollection>
      </dx:ASPxPanel>

  <dx:ASPxPanel
    ID="CustomeComponentContainer"
    runat="server"
    CssClass="custome-component-container"
  >
    <PanelCollection>
      <dx:PanelContent> </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>
</asp:Content>
