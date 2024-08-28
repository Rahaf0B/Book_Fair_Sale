<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="HomePage.aspx.cs"
Inherits="BookFair.HomePage" Async="true" ViewStateMode="Enabled" %>
<asp:content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .item-img-header {
      float: left;
    }

    .header-container {
      display: flex;
      flex-direction: row;
      align-items: center;
      justify-content: space-around;
      box-shadow: 1px 1px 15px 2px rgba(230, 189, 150, 0.6);
      max-width: 100%;
    }

    .btn-cart {
      border-radius: 10px;
    }

    #ContentPopUpWindow {
      left: 50% !important;
      top: 50% !important;
      transform: translateX(-50%);
    }

    .panel-footer-pager-container {
      width: 300px;
      display: flex;
      flex-direction: row;
      align-items: center;
      margin: auto;
      /*gap:50px;*/
      margin-top: 20px;
      justify-content: space-evenly;
    }

    .container-btn-pager {
      display: flex;
      flex-direction: row;
      align-items: center;
      justify-content: center;
    }

    .pager-btn {
      background-color: transparent;
      border: none;
      width: 30px;
    }

    .element-panel-container {
      margin: auto;
      width: fit-content;
      display: grid;
      padding: 20px;
      max-width: 100%;

      gap: 50px 200px;
    }

    @media (min-width: 1024px) {
      .element-panel-container {
        grid-template-columns: repeat(2, 1fr);
      }
    }

    @media (max-width: 1024px) {
      .element-panel-container {
        grid-template-columns: repeat(1, 1fr);
        gap: 20px;
      }
    }

    .options-container {
      width: 100%;
      padding: 20px;
      display: flex;
      flex-direction: row;
      gap: 15px;
      align-items: center;
      justify-content: center;
    }

    .options-input {
      width: 400px;
      border-radius: 15px;
      height: 35px;
    }

    .options-btn {
      width: fit-content !important;
      padding: 5px 15px 5px 15px;
      border-radius: 15px;
    }

    .options-serach-filter-container {
      width: 100%;
      display: flex;
      flex-direction: row;
      flex-wrap: wrap;

      max-width: 100%;
    }

    .Drop-subject-filter {
      border: #f87c1d solid;
      color: black;
      background-color: white;
      border-radius: 15px;
      align-items: center;
      text-align: center;
      height: 50px;
      width: 150px;
      font-family: "Concert One", "ConcertOne", sans-serif;
    }
    .label-no-data {
      text-align: center;
      font-size: 26px;
      color: #2f222f78;
      margin: auto;
      margin-top: 25px;
      display: block;
      width: fit-content;
    }
  </style>

  <dx:aspxpanel ID="ASPxPanel1" runat="server" CssClass="header-container">
    <panelcollection>
      <dx:panelcontent runat="server">
        <div class="left-block">
          <dx:aspxmenu
            ID="ASPxMenu1"
            runat="server"
            Orientation="Horizontal"
            HorizontalAlign="Center"
            ItemAutoWidth="false"
            ItemWrap="false"
            SeparatorWidth="0"
            EnableHotTrack="false"
            Width="100%"
            CssClass="c"
            SyncSelectionMode="None"
            Border-BorderStyle="None"
            BackColor="Transparent"
          >
            <itemstyle VerticalAlign="Middle" CssClass="item" />

            <items>
              <dx:menuitem Alignment="Left" Text>
                <itemstyle CssClass="item-img-header" />

                <image
                  Url="~/utlis/Images/icon.svg.svg"
                  Width="100px"
                  SpriteProperties-CssClass="img-responsive img-float-left"
                />
              </dx:menuitem>
            </items>

            <border BorderStyle="None"></border>
          </dx:aspxmenu>
        </div>

        <div class="right-block">
          <dx:aspxmenu
            ID="ASPxMainMenu"
            runat="server"
            Orientation="Horizontal"
            HorizontalAlign="Center"
            ItemAutoWidth="false"
            ItemWrap="false"
            SeparatorWidth="0"
            EnableHotTrack="false"
            Width="100%"
            CssClass="c"
            SyncSelectionMode="None"
            Border-BorderStyle="None"
            BackColor="Transparent"
            ShowPopOutImages="False"
            ApplyItemStyleToTemplates="true"
            ItemStyleToTemplates="true"
          >
            <itemstyle VerticalAlign="Middle" CssClass="item" />

            <items>
              <dx:menuitem
                Text="Home"
                NavigateUrl="~/HomePage.aspx"
                Alignment="Center"
                Name="HomeItem"
              />
              <dx:menuitem
                Text="Cart"
                NavigateUrl="~/CartPage.aspx"
                Alignment="Center"
                Name="CartItem"
              />
              <dx:menuitem
                Text="Orders"
                NavigateUrl="~/OrdersPage.aspx"
                Alignment="Center"
                Name="OrderItem"
              />

              <dx:menuitem
                Text="Manage Orders"
                NavigateUrl="~/OrdersManagement.aspx"
                Alignment="Center"
                Name="MangeOrderItem"
              />

              <dx:menuitem
                Text="Add Book"
                NavigateUrl="~/AddBook.aspx"
                Alignment="Center"
                Name="AddBookItem"
              />

              <dx:menuitem
                Text="Add Employee"
                NavigateUrl="~/AddEmployee.aspx"
                Alignment="Center"
                Name="AddEmpItem"
              />
            </items>

            <border BorderStyle="None"></border>
          </dx:aspxmenu>
        </div>
        <div class="account-menu">
          <dx:aspxmenu
            runat="server"
            ID="ASPxMenuAccount"
            ItemAutoWidth="false"
            ItemWrap="false"
            ShowPopOutImages="False"
            Border-BorderStyle="None"
            BackColor="Transparent"
            SeparatorWidth="0"
            ApplyItemStyleToTemplates="true"
            Width="100%"
            OnItemClick="UserMenuItemClick"
            CssClass="header-menu"
            UseSubmitBehavior="false"
          >
            <itemstyle VerticalAlign="Middle" CssClass="item" />
            <submenuitemstyle CssClass="item" />
            <submenustyle CssClass="header-sub-menu" />

            <items>
              <dx:menuitem
                Name="AccountItem"
                ItemStyle-CssClass="image-item"
                Text
              >
                <image Url="utlis/Images/user.svg" Width="20px"></image>
                <items>
                  <dx:menuitem
                    Name="SignOutItem"
                    Text="Sign out"
                    Image-Url="utlis/Images/sign-out.svg"
                    Image-Height="16px"
                  >
                    <image Height="16px" Url="~/Content/Images/sign-out.svg">
                    </image>
                  </dx:menuitem>
                </items>
                <itemstyle CssClass="image-item" />
              </dx:menuitem>
            </items>
            <border BorderStyle="None" />
          </dx:aspxmenu>
        </div>
      </dx:panelcontent>
    </panelcollection>
  </dx:aspxpanel>

  <dx:aspxpanel
    ID="AspxpanelSearchFilterContainer"
    CssClass="options-serach-filter-container"
    runat="server"
    Width="100%"
  >
    <panelcollection>
      <dx:panelcontent>
        <dx:aspxpanel
          ID="panelSearchItemsContainer"
          CssClass="options-container search-container"
          runat="server"
          Width="100%"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:aspxtextbox
                ID="SearchTextInput"
                CssClass="options-input search-input"
                runat="server"
              />
              <dx:aspxbutton
                ID="BtnSearch"
                runat="server"
                Text="Search"
                AutoPostBack="false"
                OnClick="btnSearch_Click"
                CssClass="options-btn btn-search"
              >
              </dx:aspxbutton>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>

        <dx:aspxpanel
          ID="panelFilterItemsContainer"
          CssClass="options-container filter-container"
          runat="server"
          Width="100%"
        >
          <panelcollection>
            <dx:panelcontent>
              <asp:DropDownList
                ID="DropFilter"
                AutoPostBack="true"
                CssClass="Drop-subject-filter"
                runat="server"
                OnSelectedIndexChanged="DropFilter_SelectedIndexChanged"
              >
              </asp:DropDownList>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>
      </dx:panelcontent>
    </panelcollection>
  </dx:aspxpanel>
  <dx:ASPxLabel
    runat="server"
    CssClass="label-no-data"
    ID="NoDataLabel"
    Text="There Are No Books"
  ></dx:ASPxLabel>
  <dx:aspxpanel ID="DataViewContainer" Width="100%" runat="server">
    <panelcollection>
      <dx:panelcontent>
        <dx:aspxpanel
          ID="ElementPanelContainer"
          CssClass="element-panel-container"
          runat="server"
          ViewStateMode="Enabled"
        >
          <panelcollection>
            <dx:panelcontent> </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>

        <dx:aspxpanel
          ID="FooterPagerContainer"
          CssClass="panel-footer-pager-container"
          runat="server"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:aspxlabel ID="labelPageFooter" runat="server"></dx:aspxlabel>
              <div class="container-btn-pager">
                <dx:aspxbutton
                  ID="btnPagerPrev"
                  CssClass="pager-btn"
                  runat="server"
                  Image-Url="~/utlis/Images/iconPrev.svg"
                  Image-Width="30px"
                  OnClick="btnPagerPrev_Click"
                  AutoPostBack="False"
                >
                  <image Width="30px" Url="~/utlis/Images/iconPrev.svg"></image>
                </dx:aspxbutton>
                <dx:aspxlabel
                  ID="labelPagerNumber"
                  runat="server"
                ></dx:aspxlabel>

                <dx:aspxbutton
                  ID="btnPagerNext"
                  AutoPostBack="false"
                  CssClass="pager-btn"
                  runat="server"
                  Image-Url="~/utlis/Images/iconNext.svg"
                  Image-Width="30px"
                  OnClick="btnPagerNext_Click"
                >
                  <image Width="30px" Url="~/utlis/Images/iconNext.svg"></image>
                </dx:aspxbutton>
              </div>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>
      </dx:panelcontent>
    </panelcollection>
  </dx:aspxpanel>
</asp:content>
