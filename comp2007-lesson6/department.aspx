﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="comp2007_lesson6.department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>
        Department Details
    </h1>
    <h5>
        All fields are required.
    </h5>
    <fieldset>
        <label for="txtName" class="col-sm-2">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtBudget" class="col-sm-2">Budget:</label>
        <asp:TextBox ID="txtBudget" runat="server" required MaxLength="50" TextMode="Number" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtBudget" ErrorMessage="Must be Between 0 - 20 million" MinimumValue="0" MaximumValue="200000000" Display="Dynamic" CssClass="label label-danger"></asp:RangeValidator>
    </fieldset>

    <div  class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

</asp:Content>
