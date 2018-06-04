import win32gui,win32con,win32api,win32ui
# import re
import pyautogui
import re, traceback
import time
import sys
import tempfile
import argparse



class WindowMgr:
    """Encapsulates some calls to the winapi for window management"""
    settingFile =''

    def __init__ (self):
        """Constructor"""
        self.hwnd = None

    def find_window(self,title):
        try:
            self.hwnd = win32gui.FindWindow(None, title)
            assert self.hwnd
            return self.hwnd
        except:
            pyautogui.alert(text='Not found program name ' + title + '\n' 
                            'Please open program before excute script', title='Unable to open program', button='OK')
            print ('Not found program')
            return None


    def set_onTop(self,hwnd):
        win32gui.SetForegroundWindow(hwnd)
        return win32gui.GetWindowRect(hwnd)



    def Maximize(self,hwnd):
        win32gui.ShowWindow(hwnd,win32con.SW_RESTORE)#, win32con.SW_MAXIMIZE

    def get_mouseXY(self):
        return win32gui.GetCursorPos()

    def set_mouseXY(self):
        import os.path
        import json
        x,y,w,h = win32gui.GetWindowRect(self.hwnd)
        print ('Current Window X : %s  Y: %s' %(x,y))
        fname = 'd:\\ticket\\setting.json'
        if os.path.isfile(fname) :
            dict = eval(open(fname).read())
            x1 = dict['x']
            y1 = dict['y']
            print ('Setting X : %s  Y: %s' %(x1,y1))
        win32api.SetCursorPos((x+x1,y+y1))
        win32api.mouse_event(win32con.MOUSEEVENTF_LEFTDOWN, x+x1, y+y1, 0, 0)
        win32api.mouse_event(win32con.MOUSEEVENTF_LEFTUP, x+x1, y+y1, 0, 0)
        print ('Current Mouse X %s' % self.get_mouseXY()[0])
        print ('Current Mouse Y %s' % self.get_mouseXY()[1])


    def saveFirstDataPos(self):
        x,y,w,h = win32gui.GetWindowRect(self.hwnd)
        print ('Window X : %s  Y: %s' %(x,y))
        x1,y1 = self.get_mouseXY()
        print ('Mouse X : %s  Y: %s' %(x1,y1))
        data={}
        data['x'] = x1-x
        data['y'] = y1-y
        # f = open("setting.json", "w")
        # self.settingFile
        f = open('d:\\ticket\\setting.json', "w")
        f.write(str(data))

        f.close()



    def wait(self,seconds=1,message=None):
        """pause Windows for ? seconds and print
an optional message """
        win32api.Sleep(seconds*1000)
        if message is not None:
            win32api.keybd_event(message, 0,0,0)
            time.sleep(.05)
            win32api.keybd_event(message,0 ,win32con.KEYEVENTF_KEYUP ,0)

    def typer(self,stringIn=None):
        PyCWnd = win32ui.CreateWindowFromHandle(self.hwnd)
        for s in stringIn :
            if s == "\n":
                self.hwnd.SendMessage(win32con.WM_KEYDOWN, win32con.VK_RETURN, 0)
                self.hwnd.SendMessage(win32con.WM_KEYUP, win32con.VK_RETURN, 0)
            else:
                print ('Ord %s' % ord(s))
                PyCWnd.SendMessage(win32con.WM_CHAR, ord(s), 0)
        PyCWnd.UpdateWindow()


#     import win32ui
# import time

    def WindowExists(windowname):
        try:
            win32ui.FindWindow(None, windowname)

        except win32ui.error:
            return False
        else:
            return True

def saveTicketFile(ticketFile,ticketdata):
    # data={}
    # data['ticket'] = ticket
    # data['container'] = container
    import os.path
    if os.path.isfile(ticketFile) :
        print ('Delete ticket file')
        os.remove(fname_ticket)
    f = open(ticketFile, "w")
    f.write(str(ticketdata))
    f.close()

def get_data(ticket):
    import urllib3
    # from lxml.html import parse
    http = urllib3.PoolManager()
    #Validate
    url = 'http://192.168.10.54:8080/e-Ticket/checking/validation.php?q=' + ticket
    v = http.request('GET', url)
    # v.data.decode('utf_8')
    # New paring function
    # received = parse(url).getroot()
    # data = received.text_content().split(':')

    received = v.data.decode('utf_8')
    print (received)
    data = received.split('|')
    returned_ticket = data[0].strip()
    returned_msg = data[1].strip()

    print('Return Ticket : %s' % returned_ticket )
    print('Return Message : %s' % returned_msg )
    data={}
    data['barcode']= ticket
    data['status']= v.status
    data['description'] = ''
    data['url'] = url
    # Check Ticket Match
    if ticket != returned_ticket :
        error_msg = 'Return data is mis-match , Input ticket is %s ,but returned Ticket is %s' % (ticket,returned_ticket)
        print (error_msg)
        data['description'] = error_msg
        return data
    else:
        print ('Ticket Data is match...')

    #Check Ticket Result
    if not 'PASS' in returned_msg:
        error_msg ='Ticket is not pass validation : %s : %s' % (returned_ticket,returned_msg)
        print (error_msg)
        data['description'] = error_msg
        return data
    else:
        print ('Validation is passed..')

    # sys.exit()


    
    # url = 'http://svr-lcb1app:8080/e-Ticket/GETdata.php?barcode=' + ticket
    url = 'http://192.168.10.54:8080/e-Ticket/GETdata.php?q=' + ticket
    r = http.request('GET', url)
    print(r.data)
    if r.status == 200:
        str = r.data.decode("utf-8")
        data={}
        print(str)
        print(len(str))
        if len(str)>0 :
            tmp = str.split('|')
            
            data['barcode']= tmp[0].strip()
            data['container']= tmp[1].strip()
            data['bl']= tmp[2].strip()
            data['status']= r.status
            data['description']='OK'
            data['url'] = url
        else:
            data['status']= r.status
            data['description']= 'Not found barcode :' + ticket
            data['url'] = url
    else :
        data={}
        data['status']= r.status
        data['description'] = 'Unable to access Ticket web server'
        data['url'] = url

    # Validate Ticket Info.
    print (len(ticket))
    print (len(data['barcode']))
    if ticket != data['barcode'] :
        error_msg = 'Return Container data is mis-match , Input ticket is %s ,but returned Ticket is %s' % (ticket,data['barcode'])
        print (error_msg)
        data['description'] = error_msg
        return data
    else:
        print ('Container Data is match')


    print (data)
    return data

def fill_data(hwnd,ticket_dict):
    # print (ticket_dict['barcode'])
    secs_between_keys=0.05
    if ticket_dict['description'].strip()=='OK':
        #hwnd.wait(0,0x09)
        #hwnd.wait(0,0x09)
        #hwnd.wait(0,0x09)
        pyautogui.typewrite('3', interval=secs_between_keys) #Full Out
        #hwnd.wait(0,0x09)
        if ticket_dict['container'].strip() !='':
            pyautogui.typewrite(ticket_dict['container'].strip(), interval=secs_between_keys)
        else:
            hwnd.wait(0,0x09)
            hwnd.wait(0,0x09)
        hwnd.wait(0,0x09)
        pyautogui.typewrite('M', interval=secs_between_keys)
        hwnd.wait(0,0x09)
        pyautogui.typewrite(ticket_dict['bl'].strip(), interval=secs_between_keys)
        hwnd.wait(0,0x09)
        pyautogui.typewrite('LOCAL' ,interval=secs_between_keys)
    else:
        pyautogui.alert(text=ticket_dict['description'].strip(), title='Unable to get barcode details', button='OK')


def go_gateOut_page():
    # Start at First page of CTCS program
    secs_between_keys=0.01
    pyautogui.press('f12')
    pyautogui.press('f12')
    pyautogui.press('f12')
    pyautogui.press('f12')

    pyautogui.typewrite('1', interval=secs_between_keys) #Work with CTCS
    pyautogui.press('enter')

    pyautogui.typewrite('4', interval=secs_between_keys) #GATE
    pyautogui.press('enter')


    pyautogui.typewrite('2', interval=secs_between_keys) #GATE In
    pyautogui.press('enter')

def fill_gateOut(container,plate):
    secs_between_keys=0.01
    pyautogui.typewrite(container, interval=secs_between_keys) #Work with CTCS
    pyautogui.press('enter')
    pyautogui.press('tab')
    pyautogui.typewrite(plate, interval=secs_between_keys)
    pyautogui.press('enter')
    time.sleep(1)
    pyautogui.press('enter')
    print ('Gate-Out Successful...')

def go_gateIn_page():
    # Start at First page of CTCS program
    secs_between_keys=0.1
    pyautogui.press('f12')
    pyautogui.press('f12')
    pyautogui.press('f12')
    pyautogui.press('f12')

    pyautogui.typewrite('1', interval=secs_between_keys) #Work with CTCS
    pyautogui.press('enter')

    pyautogui.typewrite('4', interval=secs_between_keys) #GATE
    pyautogui.press('enter')


    pyautogui.typewrite('1', interval=secs_between_keys) #GATE In
    pyautogui.press('enter')

    # Create Page
    pyautogui.press('f6')

    # sys.exit()

def fill_gateIn():
    plate_number        = pyautogui.prompt(text='Please input License Plate Number :', title='Plate Number' , default='')
    if plate_number == 'quit' or plate_number == None or plate_number == 'q' or plate_number == 'Q'  :
        print ('See you ,Bye Bye..')
        sys.exit()
    container_number    = ''
    import re
    rex = re.compile("^[A-Z]{4}[0-9]{7}$")
    while not rex.match(container_number): 
        container_number    = pyautogui.prompt(text='Please input Container number :', title='Container Number' , default='')
        if container_number == 'quit' or container_number == 'q' or container_number == 'Q'  :
            print ('See you ,Bye Bye..')
            sys.exit()
    
    truck_company = 'X'
    if 'MSKU' in container_number or 'MRKU' in container_number :
        truck_company = '700001'
    # Start to Fill
    secs_between_keys=0.01
    pyautogui.typewrite(plate_number, interval=secs_between_keys)
    pyautogui.press('tab')

    pyautogui.typewrite(truck_company, interval=secs_between_keys)
    pyautogui.press('tab')

    pyautogui.press('tab')
    pyautogui.typewrite('3', interval=secs_between_keys)

    pyautogui.typewrite(container_number, interval=secs_between_keys)
    pyautogui.press('tab')

    pyautogui.typewrite('M', interval=secs_between_keys)


    print ('Successful')
    pyautogui.press('enter')
    time.sleep(1)
    pyautogui.press('enter')
    time.sleep(1)
    pyautogui.press('enter')
    return (container_number,plate_number)

def main():
    try:
        import os.path
        ldir = tempfile.mkdtemp()
        parser = argparse.ArgumentParser()
        parser.add_argument('-d', '--directory', default=ldir)
        args = parser.parse_args()
        tmpDir = args.directory
        print (tmpDir)

        fname = tmpDir + 'setting.json'

        fname_ticket = tmpDir + 'ticket.json'
        if os.path.isfile(fname_ticket) :
            print ('Delete ticket file')
            os.remove(fname_ticket)


        # print ('Exit')
        # sys.exit()

        settingFile = fname
        print (fname)
        # regex = "Untitled - Notepad"
        # regex = "Microsoft Excel - Book1"
        win = WindowMgr()

        regex_gatein = "Session A - [24 x 80]"  
        regex_gateout = "Session B - [24 x 80]"     
        wh_in = win.find_window(regex_gatein)
        if wh_in == None :
            sys.exit()

        wh_out = win.find_window(regex_gateout)
        if wh_out == None :
            sys.exit()
        

        
        # Fill Gate-In first
        (x,y,w,h) = win.set_onTop(wh_in)
        go_gateIn_page()
        (container,plate) = fill_gateIn()

        # Fill Gate-Out
        (x,y,w,h) = win.set_onTop(wh_out)
        go_gateOut_page()
        fill_gateOut(container,plate)


    except:
        f = open(tmpDir + "log.txt", "w")
        f.write(traceback.format_exc())
        print(traceback.format_exc())






main()

#2558