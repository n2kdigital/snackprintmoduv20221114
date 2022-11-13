Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
    Public Const eClear As String = Chr(27) + "@"
    Public Const eCentre As String = Chr(27) + Chr(97) + "1"
    Public Const eLeft As String = Chr(27) + Chr(97) + "0"
    Public Const eRight As String = Chr(27) + Chr(97) + "2"
    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    Public Const eCut As String = Chr(27) + "i" + vbCrLf
    Public Const eSmlText As String = Chr(27) + "!" + Chr(1)
    Public Const eNmlText As String = Chr(27) + "!" + Chr(0)
    Public Const eInit As String = eNmlText + Chr(13) + Chr(27) + "c6" + Chr(1) + Chr(27) + "R3" + vbCrLf
    Public Const eBigCharOn As String = Chr(27) + "!" + Chr(56)
    Public Const eBigCharOff As String = Chr(27) + "!" + Chr(0)
    Public Const space As String = ""

    Dim ESC5 As String = Chr(&H1B) + "!" + Chr(17) ' Double hight font mode
    Dim ESC6 As String = Chr(&H1B) + "!" + Chr(1) ' Cancel Double hight font mode


    Private prn As New RawPrinterHelper

    Private PrinterName As String = "POS-80C"
    Private Odbc As String = "maxsales"
    Private Db As String = "bdmaxsales"
    Private Bar As String = ""
    Private Bar2 As String = ""
    Private Bar3 As String = ""
    Private User As String = "c16_root"
    Private Pwd As String = "maxsales2020"
    Private Entete As String = ""
    Private Ent1 As String = ""
    Private Ent2 As String = ""
    Private Ent3 As String = ""
    Private Ent4 As String = ""
    Private Ent5 As String = ""
    Private Typedoc As Boolean = True
    Private Typeimpr As String = "Cmd"
    Private Typeimprencour As String = ""
    Private Rubrimpr As String = ""

    Private Tblprint As New ArrayList

    Private Sub initvalues()

        Dim CurDir As String = My.Application.Info.DirectoryPath
        Dim filename As String = CurDir + "\Config.txt"
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(filename)
        Dim a As String

        Dim i As Integer = 1
        Do
            a = reader.ReadLine
            If i = 1 Then Odbc = a
            If i = 2 Then Db = a
            If i = 3 Then User = a
            If i = 4 Then Pwd = a
            If i = 5 Then Entete = a
            If i = 6 Then Bar = a
            If i = 7 Then Bar2 = a
            If i = 8 Then Bar3 = a
            If i = 9 Then PrinterName = a
            If i = 10 Then Rubrimpr = a
            If i = 11 Then Ent1 = a
            If i = 12 Then Ent2 = a
            If i = 13 Then Ent3 = a
            If i = 14 Then Ent4 = a
            If i = 15 Then Ent5 = a
            i = i + 1
        Loop Until a Is Nothing
        reader.Close()

        txtbar.Text = Bar
        txtbar2.Text = Bar2
        txtbar3.Text = Bar3
        txtdb.Text = Db
        txtodbc.Text = Odbc
        txtpassword.Text = Pwd
        txtprintername.Text = PrinterName
        txtuser.Text = User
        txtrubrique.Text = Rubrimpr


    End Sub

    Public Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub

    Public Sub PrintFooter()
        Print(eCentre + "Merci pour votre confiance!" + eLeft)
        Print(vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
    End Sub

    Public Sub Print(Line As String)
        prn.SendStringToPrinter(PrinterName, Line + vbLf)
    End Sub

    Public Sub PrintDashes()
        Print(eLeft + eNmlText + "-".PadRight(42, "-"))
    End Sub

    Public Sub EndPrint()
        prn.ClosePrint()
    End Sub

    Private Sub bnExit_Click(sender As System.Object, e As System.EventArgs) Handles bnExit.Click
        prn.ClosePrint()
        Me.Close()
    End Sub

    Public Sub getData()
        Tblprint = New ArrayList
        Dim cn As OdbcConnection
        Dim Sql As String = ""
        If Rubrimpr.Equals("") Then
            If Typeimpr = "Cmd" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer A inner join produit B On A.codeprod = B.codeprod where B.codegam not in ('REPAS','CHICHA') and champ3='') and directbonus > 1000 and typedoc in ('REG','ACH','APP') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr = "Con" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where directbonus >= 1000 and typedoc in ('CON') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr = "Fac" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where vehicule = 'F' and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') and valide='OUI' And typedoc='FAC' order by numauto limit 1;"
            ElseIf Typeimpr = "Liq" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Liq') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr = "Cui" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Cui') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr = "Chi" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Chi') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr = "Elt" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Elt') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr = "App" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where directbonus >= 1000 and typedoc in ('APP') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr = "Ach" Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where directbonus >= 1000 and typedoc in ('ACH') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            End If
        Else
            If Typeimpr = "Cmd" And Rubrimpr.IndexOf("Cmd") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer A inner join produit B On A.codeprod = B.codeprod where B.codegam not in ('REPAS','CHICHA') and champ3='') and directbonus > 1000 and typedoc in ('REG') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr.Equals("Con") And Rubrimpr.IndexOf("Con") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where directbonus >= 1000 and typedoc in ('CON') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr.Equals("Fac") And Rubrimpr.IndexOf("Fac") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where vehicule = 'F' and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') and valide='OUI' And typedoc='FAC' order by numauto limit 1;"
            ElseIf Typeimpr.Equals("Liq") And Rubrimpr.IndexOf("Liq") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Liq') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr.Equals("Cui") And Rubrimpr.IndexOf("Cui") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Cui') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr.Equals("Chi") And Rubrimpr.IndexOf("Chi") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Chi') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr.Equals("Elt") And Rubrimpr.IndexOf("Elt") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where numauto in (select distinct numpiece from mouvementer where champ1='Elt') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr.Equals("App") And Rubrimpr.IndexOf("App") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where directbonus >= 1000 and typedoc in ('APP') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            ElseIf Typeimpr.Equals("Ach") And Rubrimpr.IndexOf("Ach") <> -1 Then
                Sql = "Select '' as soc,numauto, codedep, datedoc, infosub2, report from document where directbonus >= 1000 and typedoc in ('ACH') and codedep in ('" + Bar + "','" + Bar2 + "','" + Bar3 + "') order by numauto limit 1;"
            End If
        End If

        Typeimprencour = Typeimpr
        If Not Sql.Equals("") Then
            cn = New OdbcConnection("dsn=" + Odbc + ";uid=" + User + ";pwd=" + Pwd + ";")
            Dim cmd As OdbcCommand = New OdbcCommand(Sql, cn)
            cn.Open()
            Dim myReader As OdbcDataReader = cmd.ExecuteReader()
            Dim chr As String = ""
            Try
                While myReader.Read()
                    Tblprint.Add(ajustString(Entete, 45, 1))

                    If Typeimpr.Equals("Cmd") Then
                        chr = "Bon de commande No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("Con") Then
                        chr = "Bon Consigne No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("Fac") Then
                        chr = "Facture No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("Liq") Then
                        chr = "Bon Magasin No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("Cui") Then
                        chr = "Bon Cuisine No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("Chi") Then
                        chr = "Bon Chicha No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("Elt") Then
                        chr = "Bon Divers No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("App") Then
                        chr = "Bon Approvisionnement No " + myReader.GetInt32(1).ToString
                    ElseIf Typeimpr.Equals("Ach") Then
                        chr = "Bon Achat No " + myReader.GetInt32(1).ToString
                    End If

                    Tblprint.Add(ajustString(chr, 45, 1))
                    Tblprint.Add(ajustString(myReader.GetString(2), 45, 1))
                    chr = "     " + myReader.GetString(4) + " - " + myReader.GetString(3)
                    Tblprint.Add(ajustString(chr, 45, 1))
                    Tblprint.Add("---------------------------------------------")
                    If (Typeimpr = "Con" Or Typeimpr = "Cmd") Then
                        chr = ajustString("Boisson", 25, 1) + ajustString("Qté", 10, 0) + ajustString("Montant", 10, 0)
                    Else
                        chr = ajustString("Boisson", 25, 1) + ajustString("Qté", 10, 0) + ajustString("Montant", 10, 0)
                    End If

                    Tblprint.Add(chr)
                    Tblprint.Add("---------------------------------------------")


                    If Typeimpr.Equals("Cmd") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where C.codegam not in ('REPAS','CHICHA') and B.numpiece = " + myReader.GetInt32(1).ToString + " and champ3='';"
                    ElseIf Typeimpr.Equals("Con") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + ";"
                    ElseIf Typeimpr.Equals("Fac") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + ";"
                    ElseIf Typeimpr.Equals("Liq") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + " and champ1='Liq';"
                    ElseIf Typeimpr.Equals("Cui") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + " and champ1='Cui';"
                    ElseIf Typeimpr.Equals("Chi") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + " and champ1='Chi';"
                    ElseIf Typeimpr.Equals("Elt") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + " and champ1='Elt';"
                    ElseIf Typeimpr.Equals("App") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + ";"
                    ElseIf Typeimpr.Equals("Ach") Then
                        Sql = "Select C.libelle, B.quantite, B.prixtotal, B.ristourne from mouvementer B inner join produit C On B.codeprod = C.codeprod  where B.numpiece = " + myReader.GetInt32(1).ToString + ";"
                    End If


                    Dim cmd2 As OdbcCommand = New OdbcCommand(Sql, cn)
                    Dim myReader2 As OdbcDataReader = cmd2.ExecuteReader()
                    Try
                        Dim Sqte As Integer = 0
                        Dim Smontant As Integer = 0

                        While myReader2.Read()
                            Sqte += myReader2.GetInt32(1)
                            Smontant += myReader2.GetInt32(2)
                            Dim glace As String = "N"
                            If myReader2.GetInt32(3) = 1 Then glace = ""

                            If (Sqte < 0) Then Tblprint.Item(1) = "Annulation B.C No " + myReader.GetInt32(1).ToString

                            If (Typeimpr.Equals("Con") Or Typeimpr.Equals("Cmd")) Then
                                chr = ajustString(space + myReader2.GetString(0), 25, 1) + ajustString(myReader2.GetInt32(1).ToString, 8, 0) + ajustString("", 10, 0) + ajustString(glace, 2, 0)
                            Else
                                chr = ajustString(space + myReader2.GetString(0), 25, 1) + ajustString(myReader2.GetInt32(1).ToString, 8, 0) + ajustString(myReader2.GetInt32(2).ToString, 10, 0) + ajustString(glace, 2, 0)
                            End If


                            Tblprint.Add(chr)
                        End While
                        Tblprint.Add("---------------------------------------------")
                        If (Typeimpr.Equals("Con") Or Typeimpr.Equals("Cmd")) Then
                            chr = ajustString("Totaux", 25, 0) + ajustString(Sqte.ToString, 10, 0) + ajustString(Smontant.ToString, 10, 0)
                        Else
                            chr = ajustString("Totaux", 25, 0) + ajustString(Sqte.ToString, 10, 0) + ajustString(Smontant.ToString, 10, 0)
                        End If

                        Tblprint.Add(chr)
                        Tblprint.Add("---------------------------------------------")
                        If Typeimpr.Equals("Con") Then
                            Tblprint.Add(ajustString("Consigne valable pendant 30 jours", 45, 1))
                            Tblprint.Add(ajustString("à compter la date d'emission du ticket", 45, 1))
                        Else
                            Tblprint.Add(ajustString("Mode de paiement : " + myReader.GetString(5), 45, 1))
                        End If
                        Tblprint.Add("---------------------------------------------")

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error")
                    Finally
                        myReader2.Close()
                    End Try

                    Try
                        If Typeimpr.Equals("Cmd") Then
                            Sql = "Update document set directbonus = (directbonus - 1) where numauto = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd3 As New OdbcCommand(Sql, cn)
                            cmd3.ExecuteNonQuery()

                            Sql = "Update mouvementer set champ3 = 'Ok' where numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("Con") Then
                            Sql = "Update document set directbonus = (directbonus - 1) where numauto = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd3 As New OdbcCommand(Sql, cn)
                            cmd3.ExecuteNonQuery()

                            Sql = "Update mouvementer set champ3 = 'Ok' where numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("Fac") Then
                            Sql = "Update document set vehicule = 'F1' where numauto = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd32 As New OdbcCommand(Sql, cn)
                            cmd32.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("Liq") Then
                            Sql = "Update mouvementer set champ1 = 'Liq-Ok' where champ1='Liq' and numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("Cui") Then
                            Sql = "Update mouvementer set champ1 = 'Cui-Ok' where champ1='Cui' and numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("Chi") Then
                            Sql = "Update mouvementer set champ1 = 'Chi-Ok' where champ1='Chi' and numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("Elt") Then
                            Sql = "Update mouvementer set champ1 = 'Elt-Ok' where champ1='Elt' and numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("App") Then
                            Sql = "Update document set directbonus = (directbonus - 1) where numauto = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd3 As New OdbcCommand(Sql, cn)
                            cmd3.ExecuteNonQuery()

                            Sql = "Update mouvementer set champ3 = 'Ok' where numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        ElseIf Typeimpr.Equals("Ach") Then
                            Sql = "Update document set directbonus = (directbonus - 1) where numauto = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd3 As New OdbcCommand(Sql, cn)
                            cmd3.ExecuteNonQuery()

                            Sql = "Update mouvementer set champ3 = 'Ok' where numpiece = " + myReader.GetInt32(1).ToString + ";"
                            Dim cmd31 As New OdbcCommand(Sql, cn)
                            cmd31.ExecuteNonQuery()
                        End If

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End While

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error")
            Finally
                myReader.Close()
                cn.Close()
            End Try

        End If

        If Typeimpr.Equals("Cmd") Then
            Typeimpr = "Fac"
        ElseIf Typeimpr.Equals("Fac") Then
            Typeimpr = "Liq"
        ElseIf Typeimpr.Equals("Liq") Then
            Typeimpr = "Cui"
        ElseIf Typeimpr.Equals("Cui") Then
            Typeimpr = "Con"
        ElseIf Typeimpr.Equals("Con") Then
            Typeimpr = "Chi"
        ElseIf Typeimpr.Equals("Chi") Then
            Typeimpr = "Elt"
        ElseIf Typeimpr.Equals("Elt") Then
            Typeimpr = "App"
        ElseIf Typeimpr.Equals("App") Then
            Typeimpr = "Ach"
        ElseIf Typeimpr.Equals("Ach") Then
            Typeimpr = "Cmd"
        End If
    End Sub

    Public Function ajustString(str As String, l As Integer, s As Integer)
        Dim spc As String = "                                                                                          "

        If s = 1 Then
            Dim str2 = str + spc
            Return str2.Substring(0, l)
        Else
            Dim str2 = spc + str
            Dim len As Integer = str2.Length

            Return str2.Substring(len - l, l)
        End If
    End Function

    Public Sub printreceipt()
        StartPrint()
        If prn.PrinterIsOpen = True Then
            Dim i As Integer = 0
            For Each txt In Tblprint
                If i = 0 Then
                    If (Ent1 <> "") Then Print(eBigCharOn + eLeft + Ent1 + eBigCharOff)
                    If (Ent2 <> "") Then Print(eNmlText + eLeft + Ent2)
                    If (Ent3 <> "") Then Print(eNmlText + eLeft + Ent3)
                    If (Ent4 <> "") Then Print(eNmlText + eLeft + Ent4)
                    If (Ent5 <> "") Then Print(eNmlText + eLeft + Ent5)
                    If (Ent1 <> "") Then PrintDashes()

                    Print(eBigCharOn + eLeft + txt + eBigCharOff)
                ElseIf i = 1 Then
                    Print(eBigCharOn + eLeft + txt + eBigCharOff)
                Else
                    Print(eNmlText + eLeft + txt)
                End If
                i = i + 1
            Next
            PrintFooter()
            EndPrint()
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Call getData()
        If Tblprint.Count > 0 Then
            printreceipt()
            'Gestion de la double impression
            ' If Typeimprencour = "Fac" Or Typeimprencour = "Cui" Then printreceipt()
        Else
                Timer1.Enabled = True
        End If

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Timer1.Enabled = False
        btnStop.Enabled = False
        btnStar.Enabled = True
    End Sub

    Private Sub btnStar_Click(sender As Object, e As EventArgs) Handles btnStar.Click

        PrinterName = txtprintername.Text
        Odbc = txtodbc.Text
        Db = txtdb.Text
        User = txtuser.Text
        Pwd = txtpassword.Text
        Bar = txtbar.Text
        Bar2 = txtbar2.Text
        Bar3 = txtbar3.Text

        Timer1.Enabled = True
        btnStop.Enabled = True
        btnStar.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initvalues()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label7_DoubleClick(sender As Object, e As EventArgs) Handles Label7.DoubleClick
        txtrubrique.Enabled = True
        txtbar.Enabled = True
        txtbar2.Enabled = True
        txtbar3.Enabled = True
        txtprintername.Enabled = True
        txtodbc.Enabled = True
        txtdb.Enabled = True
        txtuser.Enabled = True
        txtpassword.Enabled = True
    End Sub
End Class
